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


        public async Task FetchPlayerDataAsync()
        {
            data_ = await NetworkHelper.FetchAsync<Sc2PlayerData>(
                $"{Program.battleNetUri}/sc2/profile/user?access_token={Program.oauthToken}");
        }

        public async Task<long?> FetchLocalPlayerMmrAsync(string displayName, Sc2Race race)
        {
            var character = GetPlayerCharacter(displayName);
            if (character == null)
            {
                return null;
            }

            var laddersSolo = await LadderManager.FetchLaddersAsync(
                string.Format("/profile/{0}/{1}/{2}", character.id,
                    character.realm, character.displayName),
                "LOTV_SOLO");

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
