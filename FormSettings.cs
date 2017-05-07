using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Sc2StreamChatAssistant
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();

            Sc2ClientPortSelector.Value = Program.Sc2ClientHelper.NetworkPort;
            OnSc2ClientConntectionChanged(false);

            InitProfilesList(playersList1, Program.PlayerProfiles);
            InitProfilesList(playersList2, Program.FriendsProfiles);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Program.Sc2ClientHelper.Sc2ClientConntectionChanged += OnSc2ClientConntectionChanged;
            (new FormOutput()).Show();
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

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            Program.SaveSettings();
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
    }
}
