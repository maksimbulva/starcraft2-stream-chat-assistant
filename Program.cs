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

        public static ViewModel viewModel { get; private set; }

        public static string oauthToken { get; private set; }
        public static string apiKey { get; private set; }

        public static Sc2ClientHelper sc2ClientHelper = new Sc2ClientHelper();

        private static WeakReference<LiteDB.LiteDatabase> database_;
        public static LiteDB.LiteDatabase Database
        {
            get
            {
                LiteDB.LiteDatabase result = null;
                database_?.TryGetTarget(out result);
                return result;
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var db = new LiteDB.LiteDatabase(@"data.db"))
            {
                database_ = new WeakReference<LiteDB.LiteDatabase>(db);
                battleNetClient = new RestClient("https://eu.api.battle.net");
                oauthToken = @"sthbd9wz279hw8gx43u5cv2j";
                apiKey = @"jfqepr6us2a6hbsg5wsmtpnqap9rg7h5";

                playerData = new PlayerData();
                ladderMgr = new LadderManager();

                playerData.FetchPlayerDataAsync().Wait();

                viewModel = new ViewModel();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                // formOutput = new FormOutput();
                Application.Run(new FormSettings());
            }
        }
    }
}
