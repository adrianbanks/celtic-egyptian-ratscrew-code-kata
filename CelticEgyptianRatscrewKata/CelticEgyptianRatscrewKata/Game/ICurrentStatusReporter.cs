using System.Collections.Generic;

namespace CelticEgyptianRatscrewKata.Game
{
    public interface ICurrentStatusReporter
    {
        void UpdateCurrentStatus(Card topCard, Player nextPlayer, Dictionary<string, int> playerCards, int numberOfCardsOnStack);
    }
}