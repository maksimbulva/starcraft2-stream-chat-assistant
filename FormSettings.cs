using RestSharp;
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
        private RestRequestAsyncHandle sc2RequestProfileHandle_;

        public FormSettings()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Program.playerData.ActiveCharacterChanged += onActiveCharacterChanged;

            readProfileInfo();
        }

        private async void onActiveCharacterChanged(Sc2Character character)
        {
            //Text = "Reading ladders...";
            await Program.ladderMgr.pullLadders(character);
        }

        private void readProfileInfo()
        {
            //Text = "Reading profile info...";
            var request = new RestRequest("sc2/profile/user", Method.POST);
            request.AddParameter("access_token", Program.oauthToken);
            NetworkHelper.requestOnce<Sc2Profile>(this, Program.battleNetClient,
                request, ref sc2RequestProfileHandle_,
                x =>
                {
                    // TODO - make profile selection
                    // TODO - do range check
                    Program.playerData.activeCharacter = x.characters[0];
                });
            (new FormOutput()).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (new FormOutput()).Show();
        }
    }
}
