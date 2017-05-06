using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sc2StreamChatAssistant
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

        public PlayerInfo MyPlayerInfo
        {
            get
            {
                if (players != null && players.Count > 0)
                {
                    return players.FirstOrDefault(x =>
                        Program.PlayerProfiles.Find(y => y.DisplayName == x.name) != null)
                        ?? players[0];
                }
                return null;
            }
        }

        public PlayerInfo getOtherPlayerInfo(PlayerInfo player)
        {
            return players.FirstOrDefault(x => !ReferenceEquals(x, player));
        }

        public void SortPlayers()
        {
            if (players != null)
            {
                var myPlayer = MyPlayerInfo;
                var index = players.FindIndex(x => ReferenceEquals(x, myPlayer));
                if (index >= 0)
                {
                    players.RemoveAt(index);
                    players.Insert(0, myPlayer);
                }
            }
        }
    }
}
