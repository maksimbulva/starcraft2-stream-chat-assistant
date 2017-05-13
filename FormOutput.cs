using System;
using System.Windows.Forms;

namespace Sc2StreamChatAssistant
{
    public partial class FormOutput : Form
    {
        private string templatePage1vs1_;
        private string templatePage2vs2_;

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
            templatePage1vs1_ = System.IO.File.ReadAllText("template_output_1vs1.html");
            templatePage2vs2_ = System.IO.File.ReadAllText("template_output_2vs2.html");
            OnTimerTick(null, null);
            Program.ViewModel.WinsCountChanged += _ => UpdateBrowserPage();
            Program.ViewModel.LosesCountChanged += _ => UpdateBrowserPage();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private async void OnTimerTick(object sender, EventArgs e)
        {
            sc2HostFetchTimer.Enabled = false;
            await Program.ViewModel.UpdateCurrentGameAsync();
            UpdateBrowserPage();
            sc2HostFetchTimer.Enabled = true;
        }

        private void UpdateBrowserPage()
        {
            var viewModel = Program.ViewModel;

            var curPage = string.IsNullOrEmpty(viewModel.GetPlayerName(3))
                ? templatePage1vs1_
                : templatePage2vs2_;

            curPage = curPage
                .Replace("%wins_count%", viewModel.WinsCount.ToString())
                .Replace("%loses_count%", viewModel.LosesCount.ToString());

            for (int i = 1; i <= 4; ++i)
            {
                string playerName = viewModel.GetPlayerName(i - 1);
                string playerRace = Sc2RaceToString(viewModel.GetPlayerRace(i - 1));
                string playerNameWithRace = null;
                if (!string.IsNullOrEmpty(playerName))
                {
                    playerNameWithRace = $"{playerName} ({playerRace})";
                }

                curPage = curPage
                    .Replace($"%player{i}_name%", playerName)
                    .Replace($"%player{i}_race%", playerRace)
                    .Replace($"%player{i}_mmr%", viewModel.GetPlayerMmr(i - 1).Item1)
                    .Replace($"%player{i}_name_race%", playerNameWithRace);
            }

            var myMmr = viewModel.GetPlayerMmr(0);
            string myMmrWithProgress = null;
            if (!string.IsNullOrEmpty(myMmr.Item1))
            {
                myMmrWithProgress = $"{myMmr.Item1} ({myMmr.Item2})";
            }

            curPage = curPage
                .Replace("%player1_mmr_progress%", myMmr.Item2)
                .Replace("%player1_mmr_with_progress%", myMmrWithProgress);

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
