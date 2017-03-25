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
            public List<string> activeScreens { get; set; }
        }

        public delegate void GameFinishedEventHandler(Sc2Game game);
        public event GameFinishedEventHandler GameFinished;

        public delegate void CurrentGameUpdatedEventHandler(Sc2Game game);
        public event CurrentGameUpdatedEventHandler currentGameUpdated;

        private readonly RestClient restClient_ = new RestClient("http://127.0.0.1:6120");

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

        public async Task updateCurrentGame()
        {
            var responseUi = await restClient_.ExecuteTaskAsync<Sc2UiScreenList>(
                new RestRequest("ui", Method.POST));
            if (responseUi.ResponseStatus != ResponseStatus.Completed
                || responseUi.Data == null)
            {
                return;
            }
            var responseGame = await restClient_.ExecuteTaskAsync<Sc2Game>(
                new RestRequest("game", Method.POST));
            if (responseGame.ResponseStatus != ResponseStatus.Completed
                || responseGame.Data == null)
            {
                return;
            }

            Sc2Game newGameData = responseGame.Data;
            newGameData.isInProgress = responseUi.Data.activeScreens.Count == 0
                && !newGameData.isReplay
                && newGameData.players.Count >= 2
                && newGameData.players.Exists(x => x.result.Equals("Undecided",
                    StringComparison.InvariantCultureIgnoreCase));

            bool isInProgressChanged = currentGame != null
                && currentGame.isInProgress != newGameData.isInProgress;

            currentGame = newGameData;
            if (isInProgressChanged && !currentGame.isInProgress)
            {
                GameFinished?.Invoke(currentGame);
            }
        }
    }
}
