using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;

namespace Sc2FarshStreamHelper
{
    public partial class FormOutput : Form
    {
        private bool needUpdateScore_;
        private uint winsCount_;
        private uint losesCount_;
        private int? initialMmr_;
        private string htmlPage_;

        public FormOutput()
        {
            InitializeComponent();

            htmlPage_ = System.IO.File.ReadAllText("output.html");

            Program.ladderMgr.DataUpdated += _ => updateBrowserPage();
            Program.sc2ClientHelper.isInGameStateChanged += onIsInGameStateChanged;
            Program.sc2ClientHelper.currentGameUpdated += onCurrentGameUpdated;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Program.sc2ClientHelper.updateUiState(this);
            Program.sc2ClientHelper.updateCurrentGame(this);

            updateMmr();
            updateBrowserPage();
        }

        private void sc2HostFetchTimer_Tick(object sender, EventArgs e)
        {
            Program.sc2ClientHelper.updateUiState(this);
        }

        private void sc2MmrUpdateTimer_Tick(object sender, EventArgs e)
        {
            var data = Program.playerData;
            if (data.activeCharacter != null && data.activeLadder != null)
                updateMmr();
        }

        private void onIsInGameStateChanged(bool isInGame)
        {
            if (!isInGame)
            {
                needUpdateScore_ = true;
            }
            Program.sc2ClientHelper.updateCurrentGame(this);
        }

        private void onCurrentGameUpdated(Sc2Game game)
        {
            if (game != null && needUpdateScore_)
            {
                bool isWin = game.getMyPlayerInfo().result.StartsWith(
                    "V", StringComparison.InvariantCultureIgnoreCase);
                if (isWin) ++winsCount_; else ++losesCount_;
                needUpdateScore_ = false;
            }

            updateBrowserPage();
        }

        private void updateMmr()
        {
            Program.ladderMgr.updateLadder(Program.playerData.activeLadder.ladder.ladderId,
                x => x.member.Exists(
                    teamMember => teamMember.legacyLink.id 
                    == Program.playerData.activeCharacter.id));
        }

        private void updateBrowserPage()
        {
            // TODO - do some manipulation
            var activeCharacter = Program.playerData.activeCharacter;
            var activeLadder = Program.playerData.activeLadder;

            int? myMmr = null;
            if (activeCharacter != null && activeLadder != null)
            {
                var ladderData = Program.ladderMgr.getLadderTeamData(activeCharacter.id,
                    activeLadder.ladder.ladderId);
                myMmr = ladderData?.rating;
            }

            if (!initialMmr_.HasValue && myMmr.HasValue)
            {
                initialMmr_ = myMmr;
            }

            var game = Program.sc2ClientHelper.currentGame;
            var myPlayer = game?.getMyPlayerInfo();
            var theirPlayer = game?.getOtherPlayerInfo(myPlayer);

            var curPage = htmlPage_
                .Replace("%my_name%", myPlayer != null ? myPlayer.name : string.Empty)
                .Replace("%my_race%", myPlayer != null ? 
                    char.ToUpper(myPlayer.race[0]).ToString() : string.Empty)
                .Replace("%their_name%", theirPlayer != null ? theirPlayer.name : string.Empty)
                .Replace("%their_race%", theirPlayer != null ?
                    char.ToUpper(theirPlayer.race[0]).ToString() : string.Empty)
                .Replace("%wins_count%", winsCount_.ToString())
                .Replace("%loses_count%", losesCount_.ToString())
                .Replace("%my_mmr%", myMmr.HasValue ? myMmr.ToString() : string.Empty)
                .Replace("%my_mmr_progress%", myMmr.HasValue && initialMmr_.HasValue ?
                    (myMmr.Value - initialMmr_.Value).ToString("+0;-0") : string.Empty);

            webBrowserOutput.DocumentText = curPage;
        }
    }
}
