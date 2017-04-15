using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sc2StreamChatAssistant
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

            return await LadderManager.FetchPlayerMmrAsync(character.ProfilePath,
                "LOTV_SOLO", race);
        }

        public Sc2Character GetPlayerCharacter(string displayName)
        {
            return data_?.Characters?.Find(x => x.displayName == displayName);
        }
    }
}
