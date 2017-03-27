using RestSharp;
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
            var request = new RestRequest("sc2/profile/user", Method.POST);
            request.AddParameter("access_token", Program.oauthToken);
            var response = await Program.battleNetClient.ExecuteTaskAsync<Sc2PlayerData>(
                request);
            if (response.ResponseStatus != ResponseStatus.Completed
                || response.Data == null)
            {
                throw new Exception("Cannot fetch user data from battle.net");
            }
            data_ = response.Data;
        }

        public async Task<long?> FetchPlayerMmr(string displayName, string race)
        {
            var character = GetPlayerCharacter(displayName);
            if (character == null)
            {
                return null;
            }

            var client = new RestClient("https://eu.api.battle.net");
            var requestLadders = new RestRequest(
                string.Format("sc2/profile/{0}/{1}/{2}/ladders",
                    character.id, character.realm, character.displayName),
                Method.POST);
            // requestLadders.AddQueryParameter("apikey", Program.apiKey);
            var responseLadders = client.Execute(
                requestLadders);
            if (responseLadders.ResponseStatus != ResponseStatus.Completed
                || responseLadders.Content == null)
            {
                return null;
            }

            //var ladders = responseLadders.Data.currentSeason.Select(x =>
            //{
            //    if (x.ladder != null && x.ladder.Count > 0
            //        && x.ladder[0].matchMakingQueue == "LOTV_SOLO")
            //    {
            //        return x.ladder[0];
            //    }
            //    return null;
            //});

            // Program.ladderMgr.updateLadder

            return 5000;
        }

        public Sc2Character GetPlayerCharacter(string displayName)
        {
            return data_?.Characters?.Find(x => x.displayName == displayName);
        }
    }
}
