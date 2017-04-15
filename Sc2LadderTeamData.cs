using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sc2StreamChatAssistant
{
    class Sc2LadderTeamData
    {
        public class Race
        {
            [JsonProperty("en_US")]
            public string nameEnUs { get; set; }
        }

        public class RacePlayedInfo
        {
            public Race race { get; set; }
        }

        public class TeamMember
        {
            [JsonProperty("legacy_link")]
            public LegacyCharacterLink legacyLink { get; set; }

            [JsonProperty("played_race_count")]
            public List<RacePlayedInfo> racesPlayed { get; set; }

            public Sc2Race Race
            {
                get
                {
                    return Sc2RaceConverter.FromString(
                        racesPlayed != null && racesPlayed.Count > 0
                        ? racesPlayed[0].race.nameEnUs
                        : null);
                }
            }
        }

        public class LegacyCharacterLink
        {
            public ulong id { get; set; }
            public int realm { get; set; }
            public string name { get; set; }
            [JsonProperty("path")]
            public string profilePath { get; set; }
            public string DisplayName
            {
                get { return name?.Split(new char[] { '#' })[0]; }
            }
        }

        public ulong id { get; set; }
        public long rating { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }

        public List<TeamMember> member { get; set; }
    }
}
