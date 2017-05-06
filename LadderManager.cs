using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Sc2StreamChatAssistant
{
    static class LadderManager
    {
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

        public static async Task<Sc2LadderTeamData> FetchLadderTeamDataAsync(
            ulong ladderId, string profilePath, Sc2Race race)
        {
            var ladderData = await FetchLadderAsync(ladderId);
            return ladderData?.team?.Find(x => x.member.Exists(
                y =>
                {
                    return y.legacyLink != null && y.legacyLink.profilePath == profilePath
                        && y.Race == race;
                }));
        }

        public static async Task<Sc2LadderData> FetchLadderAsync(ulong ladderId)
        {
            return await NetworkHelper.FetchAsync<Sc2LadderData>(
                string.Format(@"{0}/data/sc2/ladder/{1}?access_token={2}",
                Program.battleNetUri, ladderId, Program.accessToken));
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

        public static async Task<long?> FetchPlayerMmrAsync(string displayName)
        {
            // TODO
            return 3000;
        }

        public static async Task<long?> FetchPlayerMmrAsync(string profilePath,
            string matchmakingQueue, Sc2Race race)
        {
            var laddersSolo = await FetchLaddersAsync(
                profilePath, matchmakingQueue);

            foreach (var ladderId in laddersSolo)
            {
                // TODO
                var ladderData = await LadderManager.FetchLadderTeamDataAsync(
                    ladderId.ladderId, profilePath, race);
                if (ladderData != null)
                {
                    return ladderData.rating;
                }
            }

            return null;
        }
    }
}
