using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace Sc2FarshStreamHelper
{
    class LadderManager
    {
        public class LadderEntryId
        {
            public ulong playerId;
            public ulong ladderId;

            public override bool Equals(object obj)
            {
                var rhs = obj as LadderEntryId;
                if (rhs != null)
                {
                    return playerId == rhs.playerId && ladderId == rhs.ladderId;
                }
                return base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return playerId.GetHashCode() ^ ladderId.GetHashCode();
            }
        }

        public delegate void DataUpdatedEventHandler(LadderManager sender);
        public event DataUpdatedEventHandler DataUpdated;

        private RestRequestAsyncHandle fetchLadderHandler_;

        public Dictionary<LadderEntryId, Sc2LadderTeamData> entries { get; private set; }

        public LadderManager()
        {
            entries = new Dictionary<LadderEntryId, Sc2LadderTeamData>();
        }

        public Sc2LadderTeamData getLadderTeamData(ulong playerId, ulong ladderId)
        {
            Sc2LadderTeamData result;
            entries.TryGetValue(new LadderEntryId()
            {
                playerId = playerId,
                ladderId = ladderId
            }, out result);
            return result;
        }

        public async Task updateLadder(ulong ladderId, Predicate<Sc2LadderTeamData> filter)
        {
            var request = new RestRequest("data/sc2/ladder/" + ladderId, Method.GET);
            request.AddQueryParameter("access_token", "3c89utpmn9vuqc7v4bykga5a");
            fetchLadderHandler_ = Program.battleNetClient.ExecuteAsync(
                request, response => 
                {
                    var ladderTeamData = JsonConvert.DeserializeObject<Sc2LadderData>(
                        response.Content);

                    ladderTeamData.team.ForEach(team =>
                    {
                        if (filter == null || filter(team))
                            team.member.ForEach(x => entries[
                                new LadderEntryId()
                                {
                                    playerId = x.legacyLink.id,
                                    ladderId = ladderId
                                }] = team);
                    });

                    DataUpdated?.Invoke(this);
                });
        }

        public async Task pullLadders(Sc2Character character)
        {
            var request = new RestRequest(string.Format(@"sc2/profile/{0}/{1}/{2}/ladders",
                character.id, character.realm, character.displayName), Method.POST);
            var response =
                await Program.battleNetClient.ExecutePostTaskAsync<Sc2Character.LaddersList>(request);
            if (response.ResponseStatus == ResponseStatus.Completed)
            {
                character.ladders = response.Data;
            }
            // TODO
        }
    }
}
