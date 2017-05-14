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

            public bool IsSame(PlayerInfo other)
            {
                return other != null && Name == other.Name;
            }

            public override string ToString()
            {
                return $"{Name} ({Race})";
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
                var teammate = players.Count == 4 ? Program.ViewModel.Teammate : null;
                if (!players.Exists(x => x.IsSame(teammate)))
                {
                    teammate = null;
                }

                if (players.Count == 4 && teammate == null)
                {
                    // Deduce teammate from player ids
                    var index = players.IndexOf(myPlayer);
                    ulong teammateId = 0;
                    switch (myPlayer.Id)
                    {
                        case 1:
                            teammateId = 2;
                            break;
                        case 2:
                            teammateId = 1;
                            break;
                        case 3:
                            teammateId = 4;
                            break;
                        case 4:
                            teammateId = 3;
                            break;
                    }
                    teammate = players.Find(x => x.Id == teammateId);
                }

                players = players.OrderBy(x =>
                {
                    // My player is the first player
                    if (ReferenceEquals(x, myPlayer))
                    {
                        return 0;
                    }
                    // My teammate is the second player
                    else if (x.IsSame(teammate))
                    {
                        return 1;
                    }
                    // The rest of the players
                    return 2;
                }).ToList();
            }
        }
    }
}
