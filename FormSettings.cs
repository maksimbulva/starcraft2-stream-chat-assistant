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
            // TODO
            (new FormOutput()).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (new FormOutput()).Show();
        }
    }
}
