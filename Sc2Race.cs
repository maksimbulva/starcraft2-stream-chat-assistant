using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sc2FarshStreamHelper
{
    enum Sc2Race
    {
        Unknown = 0,
        Terran,
        Zerg,
        Protoss,
        Random
    }

    static class Sc2RaceConverter
    {
        public static Sc2Race FromString(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                switch (char.ToUpper(str[0]))
                {
                    case 'T':
                        return Sc2Race.Terran;
                    case 'Z':
                        return Sc2Race.Zerg;
                    case 'P':
                        return Sc2Race.Protoss;
                    case 'R':
                        return Sc2Race.Random;
                }
            }
            return Sc2Race.Unknown;
        }
    }
}
