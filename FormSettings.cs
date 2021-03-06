﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Sc2StreamChatAssistant
{
    public partial class FormSettings : Form
    {
        class NewestReleaseData
        {
            [JsonProperty(PropertyName = "version")]
            public int Version { get; private set; }
        }

        private Form formOutput_;

        public FormSettings()
        {
            InitializeComponent();

            Sc2ClientPortSelector.Value = Program.Sc2ClientHelper.NetworkPort;
            OnSc2ClientConntectionChanged(false);

            InitProfilesList(playersList1, Program.PlayerProfiles);
            InitProfilesList(playersList2, Program.FriendsProfiles);

            playersList1.HeaderText = "Enter link to your character(s) on battle.net. For example:";
            playersList2.HeaderText = "Enter link to your friends' character on battle.net. For example:";
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            txtLegalNote.Text = System.IO.File.ReadAllText("LEGAL.txt");

            Program.Sc2ClientHelper.Sc2ClientConntectionChanged += OnSc2ClientConntectionChanged;
            Program.ViewModel.WinsCountChanged += value => numericWinsCount.Value = value;
            Program.ViewModel.LosesCountChanged += value => numericLosesCount.Value = value;

            numericWinsCount.ValueChanged += (o, _) => Program.ViewModel.WinsCount = (uint)numericWinsCount.Value;
            numericLosesCount.ValueChanged += (o, _) => Program.ViewModel.LosesCount = (uint)numericLosesCount.Value;

            formOutput_ = new FormOutput();
            formOutput_.Show();

            var releaseData = await NetworkHelper.FetchAsync<NewestReleaseData>(
                // For now the region does not matter
                Program.ServerUri + "/data/eu/client_version");
            if (releaseData.Version > Program.Version)
            {
                txtNewVersionAvailable.Visible = true;
            }

            UpdateTeammateSelectionList();
            Program.ViewModel.CurrentGameUpdated += _ => UpdateTeammateSelectionList();
        }

        private void OnSc2ClientConntectionChanged(bool isConnected)
        {
            if (isConnected)
            {
                LblConnectionToSc2.Text = "Connected";
                LblConnectionToSc2.ForeColor = Color.ForestGreen;
            }
            else
            {
                LblConnectionToSc2.Text = "Not connected";
                LblConnectionToSc2.ForeColor = Color.DarkRed;
            }
        }

        private void OnSc2ClientPortSelectorValueChanged(object sender, EventArgs e)
        {
            Program.Sc2ClientHelper.NetworkPort = (ushort)Sc2ClientPortSelector.Value;
        }

        private void OnBtnHelpClick(object sender, EventArgs e)
        {
            try
            {
                var uri = new Uri("file:///" + System.IO.Directory.GetCurrentDirectory() + "/sc2client_port_help.html");
                System.Diagnostics.Process.Start("cmd", "/C start " + uri);
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot find default browser." + Environment.NewLine
                    + "Please open sc2client_port_help.html from the application directory");
            }
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            Program.SaveSettings();
        }


        private void OnComboTeammateSelectedValueChanged(object sender, EventArgs e)
        {
            Program.ViewModel.Teammate = comboTeammate.SelectedItem as Sc2Game.PlayerInfo;
        }

        private void InitProfilesList(PlayersList control, List<Sc2PlayerData> playerData)
        {
            control.SetPlayerProfiles(playerData);
            control.ProfilesCollectionChanged += profiles =>
            {
                playerData.Clear();
                playerData.AddRange(profiles);
            };
        }

        private void UpdateTeammateSelectionList()
        {
            var game = Program.ViewModel.CurrentGame;
            if (game == null || game.players == null || game.players.Count != 4)
            {
                comboTeammate.Items.Clear();
                comboTeammate.Enabled = false;
                Program.ViewModel.Teammate = null;
                return;
            }

            // Check if the combo box contains actual list of players
            var myPlayer = game.MyPlayerInfo;
            var comboItems = new List<Sc2Game.PlayerInfo>();
            if (comboTeammate.Items != null)
            {
                foreach (var item in comboTeammate.Items)
                {
                    var playerInfo = item as Sc2Game.PlayerInfo;
                    if (playerInfo != null)
                    {
                        comboItems.Add(playerInfo);
                    }
                }
            }

            if (comboItems.Count != 3 || !comboItems.TrueForAll(
                x => game.players.Exists(y => y.IsSame(x))))
            {
                var oldTeammate = Program.ViewModel.Teammate;
                comboTeammate.Items.Clear();
                var otherPlayers = new List<Sc2Game.PlayerInfo>(game.players);
                otherPlayers.Remove(myPlayer);
                comboTeammate.Items.AddRange(otherPlayers.ToArray());
                // Try preserving previously selected teammate
                if (oldTeammate != null)
                {
                    var newTeammate = game.players.Find(x => x.IsSame(oldTeammate));
                    if (newTeammate != null)
                    {
                        comboTeammate.SelectedItem = newTeammate;
                    }
                }
            }
            comboTeammate.Enabled = true;
        }
    }
}
