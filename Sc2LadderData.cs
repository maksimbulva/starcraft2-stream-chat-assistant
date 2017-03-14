using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sc2FarshStreamHelper
{
    class Sc2LadderData
    {
        public class Link
        {
            public Sc2Href self { get; set; }
        }

        public Link _links { get; set; }
        public List<Sc2LadderTeamData> team { get; set; }
    }
}
