using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sc2StreamChatAssistant
{
    class Sc2ClientHelper
    {
        public delegate void Sc2ClientConntectionChangedEventHandler(bool value);
        public event Sc2ClientConntectionChangedEventHandler Sc2ClientConntectionChanged;

        private class Sc2UiScreenList
        {
            public List<string> ActiveScreens { get; set; }
        }

        private bool isConnected_;
        public bool IsConnected
        {
            get { return isConnected_; }
            set
            {
                if (isConnected_ != value)
                {
                    isConnected_ = value;
                    Sc2ClientConntectionChanged?.Invoke(value);
                }
            }
        }

        public ushort NetworkPort { get; set; }

        public Sc2ClientHelper(ushort port)
        {
            NetworkPort = port;
        }

        public async Task<Sc2Game> FetchCurrentGameAsync()
        {
            var uiScreenList = await NetworkHelper.FetchAsync<Sc2UiScreenList>(
                $"http://127.0.0.1:{NetworkPort}/ui");

            IsConnected = (uiScreenList != null);

            if (uiScreenList == null)
            {
                return null;
            }

            var sc2Game = await NetworkHelper.FetchAsync<Sc2Game>(
                $"http://127.0.0.1:{NetworkPort}/game");

            if (sc2Game == null || sc2Game.players == null)
            {
                return null;
            }

            sc2Game.SortPlayers();

            sc2Game.isInProgress = uiScreenList.ActiveScreens?.Count == 0
                && !sc2Game.isReplay
                && sc2Game.players.Count >= 2
                && sc2Game.players.Exists(x => x.Result.Equals(Sc2Game.GameResultUndecided,
                    StringComparison.InvariantCultureIgnoreCase));

            return sc2Game;
        }
    }
}
