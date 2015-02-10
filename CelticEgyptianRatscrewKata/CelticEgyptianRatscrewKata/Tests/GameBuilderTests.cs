using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    [TestFixture]
    class GameBuilderTests
    {
        [Test]
        public void OnePlayerWins()
        {
            const string player = "Player 1";
            var gameBuilder = new GameBuilder();
            gameBuilder.Add(player);
            var game = gameBuilder.Deal();
            Assert.That(game.Winner, Is.EqualTo(player));
        }

        [Test]
        public void WithTwoInitialPlayers_NobodyHasWon()
        {
            var gameBuilder = new GameBuilder();
            gameBuilder.Add("Player 1");
            gameBuilder.Add("Player 2");
            var game = gameBuilder.Deal();
            Assert.That(game.Winner, Is.Null);
        }
    }
}
