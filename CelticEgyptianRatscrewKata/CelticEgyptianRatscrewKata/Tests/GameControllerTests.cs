using System.Collections.Generic;
using CelticEgyptianRatscrewKata.Game;
using CelticEgyptianRatscrewKata.GameSetup;
using CelticEgyptianRatscrewKata.SnapRules;
using NSubstitute;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    public class GameControllerTests
    {
        [Test]
        public void RedRouteWinnerAfterSomeRoundsOfPlay()
        {
            // Arrange
            var gameController = CreateGameController();
            var playerA = new Player("playerA");
            var playerB = new Player("playerB");
            var playerC = new Player("playerC");
            var playerD = new Player("playerD");
            var deck = CreateNewSimpleDeck();

            // Act
            gameController.AddPlayer(playerA);
            gameController.AddPlayer(playerB);
            gameController.AddPlayer(playerC);
            gameController.AddPlayer(playerD);
            gameController.StartGame(deck);

            gameController.PlayCard(playerA);
            gameController.PlayCard(playerB);
            gameController.PlayCard(playerC);
            gameController.PlayCard(playerD);
            gameController.PlayCard(playerA);
            gameController.PlayCard(playerB);
            gameController.AttemptSnap(playerC);

            gameController.PlayCard(playerC);
            gameController.PlayCard(playerD);
            gameController.PlayCard(playerA);
            gameController.PlayCard(playerB);
            gameController.AttemptSnap(playerC);

            // Assert
            IPlayer winner;
            var hasWinner = gameController.TryGetWinner(out winner);
            Assert.True(hasWinner);
            Assert.That(winner.Name, Is.EqualTo(playerC.Name));
        }

        [Test]
        public void RedRouteNoWinnerAfterSomeRoundsOfPlay()
        {
            // Arrange
            var gameController = CreateGameController();
            var playerA = new Player("playerA");
            var playerB = new Player("playerB");
            var playerC = new Player("playerC");
            var playerD = new Player("playerD");
            var deck = CreateNewSimpleDeck();

            // Act
            gameController.AddPlayer(playerA);
            gameController.AddPlayer(playerB);
            gameController.AddPlayer(playerC);
            gameController.AddPlayer(playerD);
            gameController.StartGame(deck);

            gameController.PlayCard(playerA);
            gameController.PlayCard(playerB);
            gameController.PlayCard(playerC);
            gameController.PlayCard(playerD);
            gameController.PlayCard(playerA);
            gameController.PlayCard(playerB);
            gameController.AttemptSnap(playerC);

            // Assert
            IPlayer potentialWinner;
            var hasWinner = gameController.TryGetWinner(out potentialWinner);
            Assert.False(hasWinner);
        }

        [Test]
        public void WhenAnInvalidSnapIsAttemptedCanNotSnapAgain()
        {
            //Arrange
            var gameController = CreateGameController();
            var playerA = new Player("playerA");
            var playerB = new Player("playerB");
            var deck = CreateDeckWithTwoPairedCards();

            //Act
            gameController.AddPlayer(playerA);
            gameController.AddPlayer(playerB);
            gameController.StartGame(deck);

            gameController.PlayCard(playerA); 
            gameController.AttemptSnap(playerA);  //Invalid snap..

            gameController.PlayCard(playerB);
            gameController.AttemptSnap(playerA);  //Cards paired, but player penalised

            //Assert
            //snap was not allowed, so no potential winner
            IPlayer potentialWinner;
            var hasWinner = gameController.TryGetWinner(out potentialWinner);
            Assert.False(hasWinner);

        }

        [Test]
        public void WhenAllPlayersHaveAPenalty_ThePenaltiesAreRemoved()
        {
            //Arrange
            var gameController = CreateGameController();
            var playerA = new Player("playerA");
            var playerB = new Player("playerB");
            var deck = CreateDeckWithTwoPairedCards();

            //Act
            gameController.AddPlayer(playerA);
            gameController.AddPlayer(playerB);
            gameController.StartGame(deck);

            gameController.PlayCard(playerA);
            gameController.AttemptSnap(playerA);  //Invalid snap..
            gameController.AttemptSnap(playerB);  //Invalid snap..

            gameController.PlayCard(playerB);

            gameController.AttemptSnap(playerA);

            //Assert
            //all players had a penalty => no penalties overall, so A can win
            IPlayer potentialWinner;
            var hasWinner = gameController.TryGetWinner(out potentialWinner);
            Assert.True(hasWinner);

        }

        private static GameController CreateGameController()
        {
            var gameState = new GameState();
            var completeSnapValidator = CreateCompleteSnapValidator();
            var dealer = new Dealer();
            var noneShufflingShuffler = new NoneShufflingShuffler();
            var turnController = new TurnController(completeSnapValidator, gameState);
            var penalisingTurnController = new PenalisingTurnController(turnController);
            return new GameController(gameState, penalisingTurnController, dealer, noneShufflingShuffler);
        }

        private static ISnapValidator CreateCompleteSnapValidator()
        {
            var rules = new ISnapRule[]
                        {
                            new DarkQueenSnapRule(),
                            new SandwichSnapRule(),
                            new StandardSnapRule()
                        };
            return new SnapValidator(rules);
        }

        public static Cards CreateNewSimpleDeck()
        {
            return Cards.With(
                new Card(Suit.Clubs, Rank.Three),
                new Card(Suit.Diamonds, Rank.Three),
                new Card(Suit.Clubs, Rank.Five),
                new Card(Suit.Clubs, Rank.Four),
                new Card(Suit.Clubs, Rank.Six),
                new Card(Suit.Diamonds, Rank.Seven),
                new Card(Suit.Clubs, Rank.Eight),
                new Card(Suit.Clubs, Rank.Seven),
                new Card(Suit.Clubs, Rank.Ten),
                new Card(Suit.Clubs, Rank.Nine)
                );
        }

        public static Cards CreateDeckWithTwoPairedCards()
        {
            return Cards.With
                (
                    new Card(Suit.Clubs, Rank.Three),
                    new Card(Suit.Spades, Rank.Three)
                );
        }

    }

    public class NoneShufflingShuffler : IShuffler
    {
        public Cards Shuffle(Cards deck)
        {
            return new Cards(deck);
        }
    }
}