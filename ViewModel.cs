using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sc2FarshStreamHelper
{
    class ViewModel
    {
        private class PlayerMmr
        {
            public long currentMmr;
            public long initialMmr;
        }

        public delegate void GameFinishedEventHandler(Sc2Game game);
        public event GameFinishedEventHandler GameFinished;

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

        public async Task UpdateCurrentGame()
        {
            var newGameData = await Program.sc2ClientHelper.FetchCurrentGame();

            bool isInProgressChanged = currentGame != null
                && currentGame.isInProgress != newGameData.isInProgress;

            currentGame = newGameData;

            if (isInProgressChanged && !currentGame.isInProgress)
            {
                GameFinished?.Invoke(currentGame);
            }

            for (int playerIndex = 0; playerIndex < 2; ++playerIndex)
            {
                var playerName = GetPlayerName(playerIndex);
                if (playerName != null)
                {
                    var playerRace = GetPlayerRace(0);
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
                            // TODO
                            foreach (var p in
                                playersCollection?.Find(x => x.DisplayName == "Pollen" /*playerName*/))
                            {
                                if (p != null)
                                {

                                }
                            }
                        }
                    }
                    if (mmr.HasValue)
                    {
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

        private string MakeMmrDictionaryKey(string playerName, Sc2Race playerRace)
        {
            return string.Empty; // playerName + "@" + playerRace;
        }
    }
}
