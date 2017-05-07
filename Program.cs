using Newtonsoft.Json;
using Sc2FarshStreamHelper.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;

namespace Sc2StreamChatAssistant
{
    static class Program
    {
        public static List<Sc2PlayerData> PlayerProfiles { get; private set; }
        public static List<Sc2PlayerData> FriendsProfiles { get; private set; }

        public static string RecentSc2Region { get; set; }

        public static ViewModel ViewModel { get; private set; }

        public static Uri ServerUri { get; private set; }

        public static Sc2ClientHelper Sc2ClientHelper { get; private set; }

        private static WeakReference<HttpClient> httpClient_;
        public static HttpClient HttpClient
        {
            get
            {
                httpClient_.TryGetTarget(out HttpClient result);
                return result;
            }
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

            RecentSc2Region = Settings.Default.RecentSc2Region;

            Sc2ClientHelper = new Sc2ClientHelper(Settings.Default.Sc2ClientPort);

            PlayerProfiles = DeserializePlayerProfiles(Settings.Default.PlayerProfiles);
            FriendsProfiles = DeserializePlayerProfiles(Settings.Default.FrinedsProfiles);

            using (var httpClient = new HttpClient())
            {
                httpClient_ = new WeakReference<HttpClient>(httpClient);

                ViewModel = new ViewModel();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormSettings());
            }
        }

        public static void SaveSettings()
        {
            Settings.Default.Sc2ClientPort = Sc2ClientHelper.NetworkPort;
            Settings.Default.PlayerProfiles = new StringCollection();
            Settings.Default.PlayerProfiles.AddRange(
                SerializePlayerProfiles(PlayerProfiles).ToArray());
            Settings.Default.FrinedsProfiles = new StringCollection();
            Settings.Default.FrinedsProfiles.AddRange(
                SerializePlayerProfiles(FriendsProfiles).ToArray());
            Settings.Default.RecentSc2Region = RecentSc2Region;
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
