using System.Linq;
using CelticEgyptianRatscrewKata.Game;

namespace CelticEgyptianRatscrewKata.SnapRules
{
    public class CallOutSnapRule : ISnapRule
    {
        private readonly GameState _gameState;

        public CallOutSnapRule(GameState gameState)
        {
            _gameState = gameState;
        }

        public bool IsSnapValid(Cards cardStack)
        {
            var topCard = cardStack.FirstOrDefault();
            return topCard != null && topCard.Rank == _gameState.CurrentCalledOutRank;
        }
    }
}
