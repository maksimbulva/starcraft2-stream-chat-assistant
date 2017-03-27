using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sc2FarshStreamHelper
{
    class Sc2ClientHelper
    {
        private class Sc2UiScreenList
        {
            public List<string> ActiveScreens { get; set; }
        }

        private readonly RestClient restClient_ = new RestClient("http://127.0.0.1:6120");

        public async Task<Sc2Game> FetchCurrentGame()
        {
            var responseUi = await restClient_.ExecuteTaskAsync<Sc2UiScreenList>(
                new RestRequest("ui", Method.POST));
            if (responseUi.ResponseStatus != ResponseStatus.Completed
                || responseUi.Data == null)
            {
                return null;
            }
            var responseGame = await restClient_.ExecuteTaskAsync<Sc2Game>(
                new RestRequest("game", Method.POST));
            if (responseGame.ResponseStatus != ResponseStatus.Completed
                || responseGame.Data == null)
            {
                return null;
            }

            Sc2Game newGameData = responseGame.Data;
            newGameData.isInProgress = responseUi.Data.ActiveScreens.Count == 0
                && !newGameData.isReplay
                && newGameData.players.Count >= 2
                && newGameData.players.Exists(x => x.result.Equals("Undecided",
                    StringComparison.InvariantCultureIgnoreCase));

            return newGameData;
        }
    }
}
