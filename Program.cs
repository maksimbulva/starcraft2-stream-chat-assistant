using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sc2FarshStreamHelper
{
    static class Program
    {
        public static PlayerData playerData { get; private set; }
        public static LadderManager ladderMgr { get; private set; }

        public static RestClient battleNetClient { get; private set; }

        public static string oauthToken { get; private set; }
        public static string apiKey { get; private set; }

        public static Sc2ClientHelper sc2ClientHelper = new Sc2ClientHelper();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            battleNetClient = new RestClient("https://eu.api.battle.net");
            oauthToken = @"sthbd9wz279hw8gx43u5cv2j";
            apiKey = @"jfqepr6us2a6hbsg5wsmtpnqap9rg7h5";

            playerData = new PlayerData();
            ladderMgr = new LadderManager();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // formOutput = new FormOutput();
            Application.Run(new FormSettings());
        }
    }
}
