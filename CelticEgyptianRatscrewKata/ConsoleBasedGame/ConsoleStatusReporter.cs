using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CelticEgyptianRatscrewKata;
using CelticEgyptianRatscrewKata.Game;

namespace ConsoleBasedGame
{
    class ConsoleStatusReporter : ICurrentStatusReporter
    {
        public void UpdateCurrentStatus(Card topCard, Player nextPlayer, Dictionary<string, int> playerCards, int numberOfCardsOnStack)
        {
            Console.WriteLine("Top Card: {0}", topCard);
            Console.WriteLine("Next player: {0}", nextPlayer);
            foreach (KeyValuePair<string, int> playerCard in playerCards)
            {
                Console.WriteLine("Player {0} has {1} cards left", playerCard.Key, playerCard.Value);
            }
            Console.WriteLine("Number of cards in stack {0}", numberOfCardsOnStack);

        }
    }
}
