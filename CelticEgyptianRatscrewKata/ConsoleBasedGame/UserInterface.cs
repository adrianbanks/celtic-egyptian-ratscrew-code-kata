using System;
using System.Collections.Generic;
using CelticEgyptianRatscrewKata;
using CelticEgyptianRatscrewKata.Game;

namespace ConsoleBasedGame
{
    class UserInterface : ICurrentStatusReporter
    {
        public IEnumerable<PlayerInfo> GetPlayerInfoFromUserLazily()
        {
            bool again;
            do
            {
                Console.Write("Enter player name: ");
                var playerName = Console.ReadLine();
                var playCardKey = AskForKey("Enter play card key: ");
                var snapKey = AskForKey("Enter snap key: ");
                yield return new PlayerInfo(playerName, playCardKey, snapKey);

                var createPlayerKey = AskForKey("Create another player? (y|n): ");
                again = createPlayerKey.Equals('y');
            } while (again);
        }

        private static char AskForKey(string prompt)
        {
            Console.Write(prompt);
            var response = Console.ReadKey().KeyChar;
            Console.WriteLine();
            return response;
        }

        public bool TryReadUserInput(out char userInput)
        {
            ConsoleKeyInfo keyPress = Console.ReadKey();
            Console.WriteLine();
            userInput = keyPress.KeyChar;
            return keyPress.Key != ConsoleKey.Escape;
        }

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