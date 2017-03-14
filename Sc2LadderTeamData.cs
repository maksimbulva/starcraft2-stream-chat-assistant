using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sc2FarshStreamHelper
{
    class Sc2LadderTeamData
    {
        public class TeamMember
        {
            [JsonProperty("legacy_link")]
            public LegacyCharacterLink legacyLink { get; set; }
        }

        public class LegacyCharacterLink
        {
            public ulong id { get; set; }
            public int realm { get; set; }
            public string name { get; set; }
        }

        public ulong id { get; set; }
        public int rating { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }

        public List<TeamMember> member { get; set; }
    }
}
