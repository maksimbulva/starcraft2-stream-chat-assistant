using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sc2FarshStreamHelper
{
    class PlayerData
    {
        private class Sc2PlayerData
        {
            public List<Sc2Character> Characters { get; set; }
        }

        private Sc2PlayerData data_;

        public delegate void ActiveCharacterChangedEventHandler(Sc2Character character);
        public event ActiveCharacterChangedEventHandler ActiveCharacterChanged;

        public delegate void ActiveLadderChangedEventHandler(Sc2Character.LadderEntry activeLadder);
        public event ActiveLadderChangedEventHandler ActiveLadderChanged;

        private Sc2Character activeCharacter_;
        public Sc2Character activeCharacter
        {
            get { return activeCharacter_; }
            set
            {
                // TODO - check if the new value if differs from the current
                activeCharacter_ = value;
                ActiveCharacterChanged?.Invoke(activeCharacter_);
            }
        }

        private Sc2Character.LadderEntry activeLadder_;
        public Sc2Character.LadderEntry activeLadder
        {
            get { return activeLadder_; }
            set
            {
                // TODO - check if the new value if differs from the current
                activeLadder_ = value;
                ActiveLadderChanged?.Invoke(activeLadder_);
            }
        }

        public async Task FetchPlayerDataAsync()
        {
            data_ = await NetworkHelper.FetchAsync<Sc2PlayerData>(
                $"{Program.battleNetUri}/sc2/profile/user?access_token={Program.oauthToken}");
        }

        public async Task<long?> FetchPlayerMmrAsync(string displayName, Sc2Race race)
        {
            var character = GetPlayerCharacter(displayName);
            if (character == null)
            {
                return null;
            }

            var ladders = await NetworkHelper.FetchAsync<Sc2Character.LaddersList>(
                string.Format("{0}/sc2/profile/{1}/{2}/{3}/ladders?apikey={4}",
                    Program.battleNetUri, character.id, character.realm,
                    character.displayName, Program.apiKey));

            var laddersSolo = new List<Sc2LadderId>();

            ladders.currentSeason.Select(x =>
                x.ladder != null && x.ladder.Count > 0
                && x.ladder[0].matchMakingQueue == "LOTV_SOLO"
                ? x.ladder[0] : null).ToList().ForEach(
                x =>
                {
                    if (x != null)
                    {
                        laddersSolo.Add(x);
                    }
                });

            foreach (var ladderId in laddersSolo)
            {
                // TODO
                var ladderData = await Program.ladderMgr.FetchLadderTeamDataAsync(
                    ladderId.ladderId, character.id, Sc2Race.Protoss);
                if (ladderData != null)
                {
                    return ladderData.rating;
                }
            }

            return null;
        }

        public Sc2Character GetPlayerCharacter(string displayName)
        {
            return data_?.Characters?.Find(x => x.displayName == displayName);
        }
    }
}
