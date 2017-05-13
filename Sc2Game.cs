using System.Collections.Generic;
using System.Linq;

namespace Sc2StreamChatAssistant
{
    class Sc2Game
    {
        public class PlayerInfo
        {
            public ulong Id { get; set; }
            public string Name { get; set; }
            // "user" or "computer"
            public string Type { get; set; }
            public string Race { get; set; }
            // "Undecided", "Defeat" or "Victory"
            public string Result { get; set; }

            public bool IsComputer
            {
                get { return !string.IsNullOrEmpty(Type) && char.ToUpper(Type[0]) == 'C'; }
            }
        }

        public const string GameResultUndecided = "Undecided";

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
                        Program.PlayerProfiles.Find(y => y.DisplayName == x.Name) != null)
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
                    // Only 2vs2 and 1vs1 modes are supported
                    if (players.Count == 4 && index > 2)
                    {
                        // Put both players from the player team to the front
                        players.Insert(0, players[2]);
                        players.RemoveAt(3);
                        players.Insert(0, players[3]);
                        players.RemoveAt(4);
                        index = players.FindIndex(x => ReferenceEquals(x, myPlayer));
                    }
                    players.RemoveAt(index);
                    players.Insert(0, myPlayer);
                }
            }
        }
    }
}
