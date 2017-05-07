using System;
using System.Windows.Forms;

namespace Sc2StreamChatAssistant
{
    public partial class FormOutput : Form
    {
        private string htmlPage_;

        protected override CreateParams CreateParams
        {
            get
            {
                // Disable close window (x) button
                var result = base.CreateParams;
                result.ClassStyle |= 0x200; // CP_NOCLOSE_BUTTON
                return result;
            }
        }

        public FormOutput()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            htmlPage_ = System.IO.File.ReadAllText("output.html");
            OnTimerTick(null, null);
        }

        private async void OnTimerTick(object sender, EventArgs e)
        {
            sc2HostFetchTimer.Enabled = false;
            await Program.ViewModel.UpdateCurrentGameAsync();
            updateBrowserPage();
            sc2HostFetchTimer.Enabled = true;
        }

        private void updateBrowserPage()
        {
            var viewModel = Program.ViewModel;
            var myMmr = viewModel.GetPlayerMmr(0);
            var theirMmr = viewModel.GetPlayerMmr(1);

            var curPage = htmlPage_
                .Replace("%my_name%", viewModel.GetPlayerName(0))
                .Replace("%my_race%", Sc2RaceToString(viewModel.GetPlayerRace(0)))
                .Replace("%their_name%", viewModel.GetPlayerName(1))
                .Replace("%their_race%", Sc2RaceToString(viewModel.GetPlayerRace(1)))
                .Replace("%wins_count%", viewModel.WinsCount.ToString())
                .Replace("%loses_count%", viewModel.LosesCount.ToString())
                .Replace("%my_mmr%", myMmr.Item1)
                .Replace("%my_mmr_progress%", myMmr.Item2)
                .Replace("%their_mmr%", theirMmr.Item1);

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
