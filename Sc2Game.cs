using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sc2FarshStreamHelper
{
    class Sc2Game
    {
        public class PlayerInfo
        {
            public ulong id { get; set; }
            public string name { get; set; }
            // "user" or "computer"
            public string type { get; set; }
            public string race { get; set; }
            // "Undecided", "Defeat" or "Victory"
            public string result { get; set; }
        }

        private const string GameResultUndecided = "Undecided";

        public bool isReplay { get; set; }
        public bool isInProgress { get; set; }

        public List<PlayerInfo> players { get; set; }

        public PlayerInfo getMyPlayerInfo()
        {
            if (players != null && players.Count > 0)
            {
                var myName = Program.playerData.activeCharacter.displayName;
                return players.FirstOrDefault(x =>
                    string.Equals(x.name, myName, StringComparison.InvariantCultureIgnoreCase))
                    ?? players[0];
            }
            return null;
        }

        public PlayerInfo getOtherPlayerInfo(PlayerInfo player)
        {
            return players.FirstOrDefault(x => !ReferenceEquals(x, player));
        }
    }
}
