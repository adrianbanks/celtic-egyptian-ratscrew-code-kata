using System.Linq;
using CelticEgyptianRatscrewKata.Game;

namespace CelticEgyptianRatscrewKata.SnapRules
{
    public class CallOutSnapRule : ISnapRule
    {
        private readonly IGameState _gameState;

        public CallOutSnapRule(IGameState gameState)
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
