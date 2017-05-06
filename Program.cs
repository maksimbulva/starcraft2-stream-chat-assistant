using Newtonsoft.Json;
using Sc2FarshStreamHelper.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sc2StreamChatAssistant
{
    static class Program
    {
        public static List<Sc2PlayerData> PlayerProfiles { get; private set; }
        public static List<Sc2PlayerData> FriendsProfiles { get; private set; }

        public static ViewModel viewModel { get; private set; }

        public static string oauthToken { get; private set; }
        public static string accessToken { get; private set; }
        public static string apiKey { get; private set; }

        public static Uri ServerUri { get; private set; }

        public static Sc2ClientHelper sc2ClientHelper;

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
            if (string.IsNullOrWhiteSpace(Settings.Default.ServerUri))
            {
                Settings.Default.ServerUri = "http://5.101.121.112";
            }
            ServerUri = new Uri(Settings.Default.ServerUri);

            sc2ClientHelper = new Sc2ClientHelper(Settings.Default.Sc2ClientPort);

            PlayerProfiles = DeserializePlayerProfiles(Settings.Default.PlayerProfiles);
            // TODO
            FriendsProfiles = new List<Sc2PlayerData>();

            using (var db = new LiteDB.LiteDatabase(@"data.db"))
            {
                database_ = new WeakReference<LiteDB.LiteDatabase>(db);
                using (var httpClient = new HttpClient())
                {
                    httpClient_ = new WeakReference<HttpClient>(httpClient);

                    oauthToken = @"";
                    accessToken = @"";
                    apiKey = @"";

                    viewModel = new ViewModel();

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    // formOutput = new FormOutput();
                    Application.Run(new FormSettings());
                }
            }
        }

        public static void SaveSettings()
        {
            Settings.Default.Sc2ClientPort = sc2ClientHelper.port;
            Settings.Default.PlayerProfiles = new StringCollection();
            Settings.Default.PlayerProfiles.AddRange(
                SerializePlayerProfiles(PlayerProfiles).ToArray());
            Settings.Default.Save();
        }

        private static IEnumerable<string> SerializePlayerProfiles(List<Sc2PlayerData> profiles)
        {
            return profiles.Select(x => JsonConvert.SerializeObject(x));
        }

        private static List<Sc2PlayerData> DeserializePlayerProfiles(StringCollection encodedList)
        {
            var result = new List<Sc2PlayerData>();
            if (encodedList != null)
            {
                foreach (string encodedLine in encodedList)
                {
                    try
                    {
                        var playerData = JsonConvert.DeserializeObject<Sc2PlayerData>(encodedLine);
                        if (playerData != null)
                        {
                            result.Add(playerData);
                        }
                    }
                    finally
                    {
                    }
                }
            }
            return result;
        }
    }
}
