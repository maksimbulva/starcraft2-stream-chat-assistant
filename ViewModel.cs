﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sc2StreamChatAssistant
{
    class ViewModel
    {
        private class PlayerMmr
        {
            public long currentMmr;
            public long initialMmr;
            public DateTime timestamp = DateTime.Now;
        }

        public delegate void CurrentGameUpdatedEventHandler(Sc2Game game);
        public event CurrentGameUpdatedEventHandler CurrentGameUpdated;

        public delegate void WinsCountChangedEventHandler(uint count);
        public event WinsCountChangedEventHandler WinsCountChanged;

        public delegate void LosesCountChangedEventHandler(uint count);
        public event LosesCountChangedEventHandler LosesCountChanged;

        // Key is in form <displayName>@<race>
        private Dictionary<string, PlayerMmr> playerMmrs_ =
            new Dictionary<string, PlayerMmr>();

        private Sc2Game currentGame_;
        public Sc2Game CurrentGame
        {
            get { return currentGame_; }
            private set
            {
                // TODO - consider check if the game was really updated
                currentGame_ = value;
                CurrentGameUpdated?.Invoke(currentGame_);
            }
        }

        private uint winsCount_;
        public uint WinsCount
        {
            get { return winsCount_; }
            set
            {
                if (winsCount_ != value)
                {
                    winsCount_ = value;
                    WinsCountChanged?.Invoke(winsCount_);
                }
            }
        }

        private uint losesCount_;
        public uint LosesCount
        {
            get { return losesCount_; }
            set
            {
                if (losesCount_ != value)
                {
                    losesCount_ = value;
                    LosesCountChanged?.Invoke(losesCount_);
                }
            }
        }

        public Sc2Game.PlayerInfo Teammate { get; set; }

        public async Task UpdateCurrentGameAsync()
        {
            var newGameData = await Program.Sc2ClientHelper.FetchCurrentGameAsync();

            bool isInProgressChanged = CurrentGame != null
                && CurrentGame.isInProgress != newGameData?.isInProgress;

            CurrentGame = newGameData;

            if (isInProgressChanged && CurrentGame != null && !CurrentGame.isInProgress)
            {
                OnGameFinished(CurrentGame);
            }

            // This MMR value is used in case multiple players have the same
            // display name. Then we choose MMR of the player who has MMR
            // the closest to this value
            // Usually we set this to the local player's MMR value
            long expectedMmr = 4500;

            for (int playerIndex = 0; playerIndex < 4; ++playerIndex)
            {
                var playerInfo = GetPlayerInfo(playerIndex);
                if (playerInfo == null || playerInfo.IsComputer)
                {
                    continue;
                }

                Sc2Race playerRace = GetPlayerRace(playerIndex);

                // Do not perform lookup too often as it is slow operation
                var key = MakeMmrDictionaryKey(playerInfo.Name, playerRace);
                if (Program.FindProfile(playerInfo.Name) == null
                    && playerMmrs_.TryGetValue(key, out PlayerMmr cachedMmr)
                    && cachedMmr.timestamp.AddMinutes(5.0) < DateTime.Now)
                {
                    continue;
                }

                LadderManager.PlayerStats playerStats = 
                    await LadderManager.FetchPlayerStatsAsync(playerInfo.Name, playerRace, expectedMmr);
                if (playerStats != null)
                {
                    if (playerIndex == 0)
                    {
                        expectedMmr = playerStats.Rating;
                    }

                    if (playerMmrs_.TryGetValue(key, out PlayerMmr playerMmr))
                    {
                        playerMmr.currentMmr = playerStats.Rating;
                        playerMmr.timestamp = DateTime.Now;
                    }
                    else
                    {
                        playerMmrs_.Add(key, new PlayerMmr()
                        {
                            currentMmr = playerStats.Rating,
                            initialMmr = playerStats.Rating
                        });
                    }
                }
            }
        }

        public Sc2Game.PlayerInfo GetPlayerInfo(int index)
        {
            if (CurrentGame != null && index < CurrentGame.players.Count)
            {
                return CurrentGame.players[index];
            }
            return null;
        }

        public int PlayersCount { get { return CurrentGame?.players?.Count ?? 0; } }

        public string GetPlayerName(int index)
        {
            return GetPlayerInfo(index)?.Name;
        }

        public Sc2Race GetPlayerRace(int index)
        {
            return Sc2RaceConverter.FromString(GetPlayerInfo(index)?.Race);
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
                if (game.MyPlayerInfo.Result.StartsWith(
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
