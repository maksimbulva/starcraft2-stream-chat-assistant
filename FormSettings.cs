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
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            UpdatePlayersInDatabaseCounter();

            await Program.playerData.FetchPlayerDataAsync();

            readProfileInfo();
        }

        private void readProfileInfo()
        {
            // TODO
            (new FormOutput()).Show();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            ulong ladderIdBegin = 187298;
            ulong ladderIdEnd = 200000;
            for (ulong ladderId = ladderIdBegin; ladderId < ladderIdEnd;
                ++ladderId)
            {
                lblLaddersDiscovered.Text = string.Format(
                    "Ladders discovered: {0} / {1}",
                    ladderId - ladderIdBegin, ladderIdEnd - ladderIdBegin + 1);
                await LadderManager.DiscoverLadder(ladderId);
                UpdatePlayersInDatabaseCounter();
                // Respect the battle.net requests per second limit
                await Task.Delay(20);
            }
        }

        private void UpdatePlayersInDatabaseCounter()
        {
            var playersCollection = Program.Database?.GetCollection<Model.Players>(
                Model.playersCollectionName);
            lblPlayersInDatabase.Text = "Players in database: "
                + (playersCollection != null
                ? playersCollection.LongCount().ToString()
                : "0");
        }
    }
}
