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
        private uint winsCount_;
        private uint losesCount_;
        private int? initialMmr_;
        private string htmlPage_;

        public FormOutput()
        {
            InitializeComponent();

            htmlPage_ = System.IO.File.ReadAllText("output.html");

            Program.ladderMgr.DataUpdated += _ => updateBrowserPage();
            Program.viewModel.GameFinished += onGameFinished;
        }

        protected async override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            await Program.viewModel.UpdateCurrentGame();
            updateBrowserPage();
        }

        private async void OnTimerTick(object sender, EventArgs e)
        {
            await Program.viewModel.UpdateCurrentGame();
        }

        private void onGameFinished(Sc2Game game)
        {
            var myPlayer = game.getMyPlayerInfo();
            if (myPlayer != null)
            {
                if (game.getMyPlayerInfo().result.StartsWith(
                    "V", StringComparison.InvariantCultureIgnoreCase))
                {
                    ++winsCount_;
                }
                else
                {
                    ++losesCount_;
                }
                updateBrowserPage();
            }
        }

        private void updateBrowserPage()
        {
            var viewModel = Program.viewModel;

            // TODO - do some manipulation
            var activeCharacter = Program.playerData.activeCharacter;
            var activeLadder = Program.playerData.activeLadder;

            //int? myMmr = null;
            //if (activeCharacter != null && activeLadder != null)
            //{
            //    var ladderData = Program.ladderMgr.getLadderTeamData(activeCharacter.id,
            //        activeLadder.ladder.ladderId);
            //    myMmr = ladderData?.rating;
            //}

            //if (!initialMmr_.HasValue && myMmr.HasValue)
            //{
            //    initialMmr_ = myMmr;
            //}

            var myMmr = viewModel.GetPlayerMmr(0);

            var curPage = htmlPage_
                .Replace("%my_name%", viewModel.GetPlayerName(0))
                .Replace("%my_race%", viewModel.GetPlayerRace(0))
                .Replace("%their_name%", viewModel.GetPlayerName(1))
                .Replace("%their_race%", viewModel.GetPlayerRace(1))
                .Replace("%wins_count%", winsCount_.ToString())
                .Replace("%loses_count%", losesCount_.ToString())
                .Replace("%my_mmr%", myMmr.Item1)
                .Replace("%my_mmr_progress%", myMmr.Item2);

            webBrowserOutput.DocumentText = curPage;
        }
    }
}
