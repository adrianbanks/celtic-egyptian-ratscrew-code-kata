using System;
using System.Collections.Generic;
using System.Linq;
using CelticEgyptianRatscrewKata.Game;

namespace ConsoleBasedGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var userInterface = new UserInterface();
            GameController game = new GameFactory().Create(userInterface);

            IEnumerable<PlayerInfo> playerInfos = userInterface.GetPlayerInfoFromUserLazily().ToList();

            var playerMap = new Dictionary<string, Player>();

            foreach (PlayerInfo playerInfo in playerInfos)
            {
                var player = new Player(playerInfo.PlayerName);
                playerMap.Add(player.Name, player);
                game.AddPlayer(player);
            }

            game.StartGame(GameFactory.CreateFullDeckOfCards());

            char userInput;
            while (userInterface.TryReadUserInput(out userInput))
            {
                foreach (var playerInfo in playerInfos)
                {
                    if (playerInfo.PlayCardKey == userInput)
                    {
                        var player = playerMap[playerInfo.PlayerName];
                        var card = game.PlayCard(player);
                        Console.WriteLine("{0} played {1}", player.Name, card);
                    }
                    else if (playerInfo.SnapKey == userInput)
                    {
                        var player = playerMap[playerInfo.PlayerName];
                        game.AttemptSnap(player);
                        IPlayer winninPlayer;
                        bool won = game.TryGetWinner(out winninPlayer);

                        if (won)
                        {
                            Console.WriteLine("{0} won!", winninPlayer.Name);
                            Console.ReadLine();
                            Environment.Exit(0);
                        }
                        Console.WriteLine("No winners yet");
                    }
                }
            } 
        }
    }
}
