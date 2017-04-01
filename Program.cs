using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sc2FarshStreamHelper
{
    static class Program
    {
        public static PlayerData playerData { get; private set; }
        public static LadderManager ladderMgr { get; private set; }

        public static ViewModel viewModel { get; private set; }

        public static string oauthToken { get; private set; }
        public static string accessToken { get; private set; }
        public static string apiKey { get; private set; }

        public static Sc2ClientHelper sc2ClientHelper = new Sc2ClientHelper();

        private static WeakReference<LiteDB.LiteDatabase> database_;
        public static LiteDB.LiteDatabase Database
        {
            get
            {
                database_.TryGetTarget(out LiteDB.LiteDatabase result);
                return result;
            }
        }

        private static WeakReference<HttpClient> httpClient_;
        public static HttpClient httpClient
        {
            get
            {
                httpClient_.TryGetTarget(out HttpClient result);
                return result;
            }
        }

        public static string battleNetUri
        {
            get { return "https://eu.api.battle.net"; }
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
                using (var httpClient = new HttpClient())
                {
                    httpClient_ = new WeakReference<HttpClient>(httpClient);

                    oauthToken = @"";
                    accessToken = @"";
                    apiKey = @"";

                    playerData = new PlayerData();
                    ladderMgr = new LadderManager();

                    viewModel = new ViewModel();

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    // formOutput = new FormOutput();
                    Application.Run(new FormSettings());
                }
            }
        }
    }
}
