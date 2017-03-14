using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sc2FarshStreamHelper
{
    class PlayerData
    {
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


        public PlayerData()
        {
            // TODO - read the data from the server instead
            activeCharacter = new Sc2Character()
            {
                id = 5957073,
                realm = 1,
                displayName = "MxFarsh",
                ladders = new Sc2Character.LaddersList()
            };

            activeCharacter.ladders.currentSeason = new List<Sc2Character.LadderEntry>();
            activeCharacter.ladders.currentSeason.Add(
                new Sc2Character.LadderEntry()
                {
                    ladder = new Sc2LadderId()
                    {
                        ladderId = 190923,
                        league = "DIAMOND",
                        matchMakingQueue = "LOTV_SOLO",
                    },
                    characters = new List<Sc2Character>()
                    {
                        activeCharacter
                    }
                });

            activeLadder = activeCharacter.ladders.currentSeason[0];
        }
    }
}
