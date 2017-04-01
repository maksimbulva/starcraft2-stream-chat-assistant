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

            await Program.playerData.FetchPlayerDataAsync();

            readProfileInfo();
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
