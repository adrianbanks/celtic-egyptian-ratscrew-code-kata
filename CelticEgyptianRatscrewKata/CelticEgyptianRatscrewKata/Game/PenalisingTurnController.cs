using System.Collections.Generic;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Game
{
    public class PenalisingTurnController : ITurnController
    {
        private readonly ITurnController _turnController;
        private List<string> penalisedPlayers;

        public PenalisingTurnController(ITurnController turnController)
        {
            _turnController = turnController;
            penalisedPlayers = new List<string>();
        }

        public Card PlayCard(IPlayer player)
        {
            return _turnController.PlayCard(player);
        }

        public bool AttemptSnap(IPlayer player)
        {
            if (penalisedPlayers.Contains(player.Name))
            {
                return false;
            }
            
            var snapSuccessful = _turnController.AttemptSnap(player);

            if (!snapSuccessful)
            {
                penalisedPlayers.Add(player.Name);
            }

            return snapSuccessful;
        }
    }
}