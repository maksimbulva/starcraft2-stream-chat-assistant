using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sc2StreamChatAssistant
{
    partial class PlayersList : UserControl
    {
        public delegate void ProfilesCollectionChangedEventHandler(IEnumerable<Sc2PlayerData> profiles);
        public event ProfilesCollectionChangedEventHandler ProfilesCollectionChanged;

        public PlayersList()
        {
            InitializeComponent();
        }

        public void SetPlayerProfiles(IEnumerable<Sc2PlayerData> profiles)
        {
            listOfPlayers.Items.Clear();
            foreach (var profile in profiles)
            {
                listOfPlayers.Items.Add(profile);
            }
            NotifyProfilesCollectionChanged();
        }

        private async void OnAddPlayerClick(object sender, EventArgs args)
        {
            string url = txtPlayerUrl.Text.Trim();
            if (string.IsNullOrWhiteSpace(url))
            {
                return;
            }

            var region = BNetRegions.ExtractServerFromUrl(url);
            if (region == null)
            {
                ShowErrorMessage("The provided url does not match any battle.net region server");
                return;
            }

            int pos = url.IndexOf("profile/");
            if (pos < 0)
            {
                ShowErrorMessage("The provided url does not point to player's profile");
                return;
            }

            var parsed = url.Substring(pos + "profile/".Length).Split(new char[] { '/' });
            if (parsed.Length < 3
                || !long.TryParse(parsed[0], out long charactedId)
                || !int.TryParse(parsed[1], out int realm)
                || string.IsNullOrWhiteSpace(parsed[2]))
            {
                ShowErrorMessage("The provided url is not in correct format");

                return;
            }

            string displayName = parsed[2];

            btnAddPlayer.Enabled = false;

            var playerData = await NetworkHelper.FetchAsync<Sc2PlayerData>(
                Program.ServerUri + $"/data/{region.Code}/{charactedId}/{realm}/{displayName}/profile");

            btnAddPlayer.Enabled = true;

            if (playerData == null)
            {
                ShowErrorMessage("Cannot fetch data for the specified profile");
                return;
            }

            playerData.RegionCode = region.Code;

            txtPlayerUrl.Text = null;
            listOfPlayers.Items.Add(playerData);
            NotifyProfilesCollectionChanged();
        }

        private void OnMoveToTopClick(object sender, EventArgs e)
        {
            MoveSelectedPlayer(true);
        }

        private void OnMoveToBottomClick(object sender, EventArgs e)
        {
            MoveSelectedPlayer(false);
        }

        private void MoveSelectedPlayer(bool isMoveToTop)
        {
            if (listOfPlayers.SelectedItem != null)
            {
                var selectedPlayer = listOfPlayers.SelectedItem;
                listOfPlayers.Items.Remove(selectedPlayer);
                if (isMoveToTop)
                {
                    listOfPlayers.Items.Insert(0, selectedPlayer);
                    listOfPlayers.SelectedIndex = 0;
                }
                else
                {
                    listOfPlayers.Items.Add(selectedPlayer);
                    listOfPlayers.SelectedIndex = listOfPlayers.Items.Count - 1;
                }
                NotifyProfilesCollectionChanged();
            }
        }

        private void OnRemoveClick(object sender, EventArgs e)
        {
            if (listOfPlayers.SelectedItem != null)
            {
                int selectedIndex = listOfPlayers.SelectedIndex;
                listOfPlayers.Items.RemoveAt(selectedIndex);
                if (listOfPlayers.Items.Count > selectedIndex)
                {
                    listOfPlayers.SelectedIndex = selectedIndex;
                }
                NotifyProfilesCollectionChanged();
            }
        }

        private void NotifyProfilesCollectionChanged()
        {
            var profiles = new List<Sc2PlayerData>(listOfPlayers.Items.Count);
            foreach (var item in listOfPlayers.Items)
            {
                profiles.Add((Sc2PlayerData)item);
            }
            ProfilesCollectionChanged?.Invoke(profiles);
        }

        private static void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
