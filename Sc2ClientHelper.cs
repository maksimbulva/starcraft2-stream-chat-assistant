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
        public delegate void IsInGameStateChangedEventHandler(bool isInGame);
        public event IsInGameStateChangedEventHandler isInGameStateChanged;

        public delegate void CurrentGameUpdatedEventHandler(Sc2Game game);
        public event CurrentGameUpdatedEventHandler currentGameUpdated;

        private readonly RestClient restClient_ = new RestClient("http://127.0.0.1:6120");

        private RestRequestAsyncHandle sc2UiRequestHandle_;
        private RestRequestAsyncHandle sc2GameRequestHandle_;

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

        private bool isInGame_;
        public bool isInGame
        {
            get { return isInGame_; }
            private set
            {
                if (isInGame_ != value)
                {
                    isInGame_ = value;
                    isInGameStateChanged?.Invoke(isInGame_);
                }
            }
        }

        public void updateUiState(Control caller)
        {
            NetworkHelper.requestOnce<Sc2UiScreenList>(caller, restClient_,
                new RestRequest("ui", Method.POST), ref sc2UiRequestHandle_,
                screensList =>
                {
                    isInGame = screensList.activeScreens.Count == 0;
                });
        }

        public void updateCurrentGame(Control caller)
        {
            NetworkHelper.requestOnce<Sc2Game>(caller, restClient_,
                new RestRequest("game", Method.POST), ref sc2GameRequestHandle_,
                game =>
                {
                    currentGame = game;
                });
        }
    }
}
