using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sc2StreamChatAssistant
{
    static class LadderManager
    {
        public class PlayerStats
        {
            [JsonProperty(PropertyName = "profile_path")]
            public string ProfilePath { get; set; }

            [JsonProperty(PropertyName = "race")]
            public string RaceString { get; set; }

            public Sc2Race Race
            {
                get { return Sc2RaceConverter.FromString(RaceString); }
            }

            public long Rating { get; set; }
            public long Wins { get; set; }
            public long Losses { get; set; }
            public long Points { get; set; }
        }

        public class PlayerStatsList
        {
            public List<PlayerStats> Results { get; set; }
        }

        public static async Task<PlayerStats> FetchPlayerStatsAsync(string displayName, Sc2Race race,
            long expectedMmr)
        {
            // Check if we know this player and have her full profile path
            var profile = Program.PlayerProfiles.Find(x => x.DisplayName == displayName);
            if (profile == null)
            {
                profile = Program.FriendsProfiles.Find(x => x.DisplayName == displayName);
            }
            if (profile != null)
            {
                Program.RecentSc2Region = profile.RegionCode;
                return await NetworkHelper.FetchAsync<PlayerStats>(
                    Program.ServerUri + $"/data/{profile.RegionCode}/{profile.Id}/{profile.Realm}/"
                        + $"{profile.DisplayName}/mmr/{race}");
            }
            // Try to find player using only her display name
            // Look up in the most recent used sc2 region
            var playersList = await NetworkHelper.FetchAsync<PlayerStatsList>(
                Program.ServerUri + $"/data/{Program.RecentSc2Region}/lookup/{displayName}/{race}");
            return playersList?.Results?.OrderBy(x => Math.Abs(x.Rating - expectedMmr)).FirstOrDefault();
        }
    }
}
