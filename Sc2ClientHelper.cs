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

        public async Task<Sc2Game> FetchCurrentGame()
        {
            var uiScreenList = await NetworkHelper.FetchAsync<Sc2UiScreenList>(
                "http://127.0.0.1:6120/ui");

            if (uiScreenList == null)
            {
                return null;
            }

            var sc2Game = await NetworkHelper.FetchAsync<Sc2Game>(
                "http://127.0.0.1:6120/game");

            if (sc2Game == null || sc2Game.players == null)
            {
                return null;
            }

            sc2Game.SortPlayers();

            sc2Game.isInProgress = uiScreenList.ActiveScreens?.Count == 0
                && !sc2Game.isReplay
                && sc2Game.players.Count >= 2
                && sc2Game.players.Exists(x => x.result.Equals("Undecided",
                    StringComparison.InvariantCultureIgnoreCase));

            return sc2Game;
        }
    }
}
