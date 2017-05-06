using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sc2StreamChatAssistant
{
    class ViewModel
    {
        private class PlayerMmr
        {
            public long currentMmr;
            public long initialMmr;
        }

        public delegate void CurrentGameUpdatedEventHandler(Sc2Game game);
        public event CurrentGameUpdatedEventHandler currentGameUpdated;
        
        // Key is in form <displayName>@<race>
        private Dictionary<string, PlayerMmr> playerMmrs_ =
            new Dictionary<string, PlayerMmr>();

        private Sc2Game currentGame_;
        public Sc2Game currentGame
        {
            get { return currentGame_; }
            private set
            {
                // TODO - consider check if the game was really updated
                currentGame_ = value;
                currentGameUpdated?.Invoke(currentGame_);
            }
        }

        public uint WinsCount { get; set; }
        public uint LosesCount { get; set; }

        public async Task UpdateCurrentGameAsync()
        {
            var newGameData = await Program.sc2ClientHelper.FetchCurrentGameAsync();

            bool isInProgressChanged = currentGame != null
                && currentGame.isInProgress != newGameData?.isInProgress;

            currentGame = newGameData;

            if (isInProgressChanged && currentGame != null && !currentGame.isInProgress)
            {
                OnGameFinished(currentGame);
            }

            // This MMR value is used in case multiple players have the same
            // display name. Then we choose MMR of the player who has MMR
            // the closest to this value
            // Usually we set this to the local player's MMR value
            long expectedMmr = 4500;

            for (int playerIndex = 0; playerIndex < 2; ++playerIndex)
            {
                string playerName = GetPlayerName(playerIndex);
                if (playerName == null)
                {
                    continue;
                }

                Sc2Race playerRace = GetPlayerRace(playerIndex);
                // Check if the player is the local player
                long? mmr = await Program.playerData.FetchLocalPlayerMmrAsync(
                    playerName, playerRace);

                if (!mmr.HasValue)
                {
                    // Find player name in database
                    var database = Program.Database;
                    var playersCollection = database?.GetCollection<Model.Players>(
                        Model.playersCollectionName);
                    if (playersCollection != null)
                    {
                        var mmrCandidates = new List<long>();
                        foreach (var p in
                            playersCollection?.Find(x => x.DisplayName == playerName,
                                limit: 10))
                        {
                            var mmrCandidate = await LadderManager.FetchPlayerMmrAsync(
                                p.ProfilePath, "LOTV_SOLO", playerRace);
                            if (mmrCandidate.HasValue)
                            {
                                mmrCandidates.Add(mmrCandidate.Value);
                            }
                        }
                        if (mmrCandidates.Count > 0)
                        {
                            mmrCandidates.Sort((lhs, rhs) =>
                                Math.Abs(lhs - expectedMmr).CompareTo(Math.Abs(rhs - expectedMmr)));
                            mmr = mmrCandidates[0];
                        }
                    }
                }

                if (mmr.HasValue)
                {
                    if (playerIndex == 0)
                    {
                        expectedMmr = mmr.Value;
                    }

                    var key = MakeMmrDictionaryKey(playerName, playerRace);
                    if (playerMmrs_.TryGetValue(key, out PlayerMmr playerMmr))
                    {
                        playerMmr.currentMmr = mmr.Value;
                    }
                    else
                    {
                        playerMmrs_.Add(key, new PlayerMmr()
                        {
                            currentMmr = mmr.Value,
                            initialMmr = mmr.Value
                        });
                    }
                }
            }
        }

        public Sc2Game.PlayerInfo GetPlayerInfo(int index)
        {
            if (currentGame != null && index < currentGame.players.Count)
            {
                return currentGame.players[index];
            }
            return null;
        }

        public string GetPlayerName(int index)
        {
            return GetPlayerInfo(index)?.name;
        }

        public Sc2Race GetPlayerRace(int index)
        {
            return Sc2RaceConverter.FromString(GetPlayerInfo(index)?.race);
        }

        public Tuple<string, string> GetPlayerMmr(int index)
        {
            var playerName = GetPlayerName(index);
            var playerRace = GetPlayerRace(index);
            if (playerName != null)
            {
                if (playerMmrs_.TryGetValue(MakeMmrDictionaryKey(playerName, playerRace),
                    out PlayerMmr playerMmr))
                {
                    return new Tuple<string, string>(playerMmr.currentMmr.ToString(),
                        (playerMmr.currentMmr - playerMmr.initialMmr).ToString("+0;-0"));
                }
            }
            return new Tuple<string, string>(null, null);
        }

        private static string MakeMmrDictionaryKey(string playerName, Sc2Race playerRace)
        {
            return playerName + "@" + playerRace;
        }

        private void OnGameFinished(Sc2Game game)
        {
            if (game.MyPlayerInfo != null && !game.isReplay)
            {
                if (game.MyPlayerInfo.result.StartsWith(
                    "V", StringComparison.InvariantCultureIgnoreCase))
                {
                    ++WinsCount;
                }
                else
                {
                    ++LosesCount;
                }
            }
        }
    }
}
