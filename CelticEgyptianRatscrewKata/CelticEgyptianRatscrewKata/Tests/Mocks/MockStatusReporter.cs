using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CelticEgyptianRatscrewKata.Game;

namespace CelticEgyptianRatscrewKata.Tests.Mocks
{
    class MockStatusReporter : ICurrentStatusReporter
    {
        public void UpdateCurrentStatus(Card topCard, Player nextPlayer, Dictionary<string, int> playerCards, int numberOfCardsOnStack)
        {
            throw new NotImplementedException();
        }
    }
}
