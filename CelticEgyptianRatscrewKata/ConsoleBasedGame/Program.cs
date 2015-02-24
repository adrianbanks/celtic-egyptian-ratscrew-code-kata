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

            List<string> playerNames = userInterface.CapturePlayers();

            foreach (string playerName in playerNames)
            {
                var player = new Player(playerName);
                game.AddPlayer(player);
            }
            game.StartGame(GameFactory.CreateFullDeckOfCards());

            IPlayer winner;
            while (!game.TryGetWinner(out winner))
            {
                string nextPlayerName = game.GetNextPlayerName();
                var move = userInterface.GetNextPlayerMove(string.Format("{0} make your next move", nextPlayerName));
                game.NextMove(move);
                userInterface.DisplayMove(move);
            }
            userInterface.DisplayWinner(winner.Name);
        }
    }
}
