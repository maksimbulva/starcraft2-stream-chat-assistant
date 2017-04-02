using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        //public async Task updateLadder(ulong ladderId, Predicate<Sc2LadderTeamData> filter)
        //{
        //    var request = new RestRequest("data/sc2/ladder/" + ladderId, Method.GET);
        //    request.AddQueryParameter("access_token", "3c89utpmn9vuqc7v4bykga5a");
        //    fetchLadderHandler_ = Program.battleNetClient.ExecuteAsync(
        //        request, response => 
        //        {
        //            var ladderTeamData = JsonConvert.DeserializeObject<Sc2LadderData>(
        //                response.Content);

        //            ladderTeamData.team.ForEach(team =>
        //            {
        //                if (filter == null || filter(team))
        //                    team.member.ForEach(x => entries[
        //                        new LadderEntryId()
        //                        {
        //                            playerId = x.legacyLink.id,
        //                            ladderId = ladderId
        //                        }] = team);
        //            });

        //            DataUpdated?.Invoke(this);
        //        });
        //}

        //public async Task pullLadders(Sc2Character character)
        //{
        //    var request = new RestRequest(string.Format(@"sc2/profile/{0}/{1}/{2}/ladders",
        //        character.id, character.realm, character.displayName), Method.POST);
        //    var response =
        //        await Program.battleNetClient.ExecutePostTaskAsync<Sc2Character.LaddersList>(request);
        //    if (response.ResponseStatus == ResponseStatus.Completed)
        //    {
        //        character.ladders = response.Data;
        //    }
        //    // TODO
        //}

        public async Task<Sc2LadderTeamData> FetchLadderTeamDataAsync(ulong ladderId,
            ulong playerId, Sc2Race race)
        {
            var ladderData = await FetchLadderAsync(ladderId);
            return ladderData.team?.Find(x => x.member.Exists(
                y =>
                {
                    return y.legacyLink != null && y.legacyLink.id == playerId
                        && y.Race == race;
                }));
        }

        public static async Task<Sc2LadderData> FetchLadderAsync(ulong ladderId)
        {
            return await NetworkHelper.FetchAsync<Sc2LadderData>(
                string.Format(@"{0}/data/sc2/ladder/{1}?access_token={2}",
                Program.battleNetUri, ladderId, Program.accessToken));
        }

        public static async Task<bool> DiscoverLadder(ulong ladderId)
        {
            var database = Program.Database;
            if (database == null)
            {
                return false;
            }

            var ladderData = await FetchLadderAsync(ladderId);
            if (ladderData == null || ladderData.team == null)
            {
                return false;
            }

            var playersCollection = database.GetCollection<Model.Players>(
                Model.playersCollectionName);

            foreach (var team in ladderData.team)
            {
                team.member.ForEach(x =>
                {
                    if (!playersCollection.Exists(y => y.Id == x.legacyLink.id))
                    {
                        playersCollection.Insert(new Model.Players()
                        {
                            Id = x.legacyLink.id,
                            DisplayName = x.legacyLink.DisplayName,
                            ProfilePath = x.legacyLink.profilePath,
                        });
                    }
                });
            }

            return true;
        }

        public static async Task<List<Sc2LadderId>> FetchLaddersAsync(string profilePath,
            string matchmakingQueue)
        {
            if (profilePath[0] != '/')
            {
                profilePath = "/" + profilePath;
            }

            var ladders = await NetworkHelper.FetchAsync<Sc2Character.LaddersList>(
                string.Format("{0}/sc2{1}/ladders?apikey={2}",
                    Program.battleNetUri, profilePath, Program.apiKey));

            var result = new List<Sc2LadderId>();

            ladders?.currentSeason.Select(x =>
                x.ladder != null && x.ladder.Count > 0
                && x.ladder[0].matchMakingQueue == matchmakingQueue
                ? x.ladder[0] : null).ToList().ForEach(
                x =>
                {
                    if (x != null)
                    {
                        result.Add(x);
                    }
                });

            return result;
        }
    }
}
