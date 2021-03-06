﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Sc2StreamChatAssistant
{
    public partial class FormOutput : Form
    {
        private List<string> templatePages_ = new List<string>(4);

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
            templatePages_.Add(System.IO.File.ReadAllText("template_output_1vs1.html"));
            templatePages_.Add(System.IO.File.ReadAllText("template_output_2vs2.html"));
            templatePages_.Add(System.IO.File.ReadAllText("template_output_3vs3.html"));
            templatePages_.Add(System.IO.File.ReadAllText("template_output_4vs4.html"));
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
            int playersCount = viewModel.PlayersCount;
            string curPage = GetTemplatePage(playersCount);
            if (curPage == null)
            {
                return;
            }

            curPage = curPage
                .Replace("%wins_count%", viewModel.WinsCount.ToString())
                .Replace("%loses_count%", viewModel.LosesCount.ToString());

            for (int i = 1; i <= 8; ++i)    // 8 is the max player index in html templates
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

        private string GetTemplatePage(int playersCount)
        {
            switch (playersCount)
            {
                case 4: // 2 vs 2
                    return templatePages_[1];
                case 6: // 3 vs 3
                    return templatePages_[2];
                case 8: // 4 vs 4
                    return templatePages_[3];
            }
            return templatePages_[0]; // 1vs1
        }
    }
}
