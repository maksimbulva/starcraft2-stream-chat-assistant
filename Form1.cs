using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sc2FarshStreamHelper
{
    public partial class FormOutput : Form
    {
        private uint winsCount_;
        private uint losesCount_;
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
            sc2HostFetchTimer.Enabled = false;
            await Program.viewModel.UpdateCurrentGame();
            updateBrowserPage();
            sc2HostFetchTimer.Enabled = true;
        }

        private void onGameFinished(Sc2Game game)
        {
            if (game.MyPlayerInfo != null)
            {
                if (game.MyPlayerInfo.result.StartsWith(
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
            var myMmr = viewModel.GetPlayerMmr(0);

            var curPage = htmlPage_
                .Replace("%my_name%", viewModel.GetPlayerName(0))
                .Replace("%my_race%", Sc2RaceToString(viewModel.GetPlayerRace(0)))
                .Replace("%their_name%", viewModel.GetPlayerName(1))
                .Replace("%their_race%", Sc2RaceToString(viewModel.GetPlayerRace(1)))
                .Replace("%wins_count%", winsCount_.ToString())
                .Replace("%loses_count%", losesCount_.ToString())
                .Replace("%my_mmr%", myMmr.Item1)
                .Replace("%my_mmr_progress%", myMmr.Item2);

            webBrowserOutput.DocumentText = curPage;
        }

        private static string Sc2RaceToString(Sc2Race race)
        {
            switch (race)
            {
                case Sc2Race.Terran:
                    return "T";
                case Sc2Race.Zerg:
                    return "Z";
                case Sc2Race.Protoss:
                    return "P";
                case Sc2Race.Random:
                    return "R";
            }
            return string.Empty;
        }
    }
}
