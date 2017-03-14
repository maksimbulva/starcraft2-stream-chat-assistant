using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sc2FarshStreamHelper
{
    class Sc2Character
    {
        public class LaddersList
        {
            public List<LadderEntry> currentSeason { get; set; }
        }

        public class LadderEntry
        {
            public Sc2LadderId ladder { get; set; }
            public List<Sc2Character> characters { get; set; }
        }

        public ulong id { get; set; }
        public int realm { get; set; }
        public string displayName { get; set; }
        public LaddersList ladders { get; set; }
    }
}
