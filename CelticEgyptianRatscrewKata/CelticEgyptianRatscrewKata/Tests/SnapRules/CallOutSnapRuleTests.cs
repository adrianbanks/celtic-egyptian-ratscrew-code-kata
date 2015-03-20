using CelticEgyptianRatscrewKata.Game;
using CelticEgyptianRatscrewKata.SnapRules;
using NSubstitute;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests.SnapRules
{
    [TestFixture]
    public sealed class CallOutSnapRuleTests
    {
        [Test]
        public void SnapIsInvalid_WhenTheStackIsEmpty()
        {
            var gameState = Substitute.For<IGameState>();
            gameState.CurrentCalledOutRank.Returns(Rank.Ten);
            var snapRule = new CallOutSnapRule(gameState);
            var cards = Cards.Empty();
            
            Assert.That(snapRule.IsSnapValid(cards), Is.False);
        }

        [Test]
        public void SnapIsInvalid_WhenTheTopCardDoesNotMatchTheCallOut()
        {
            var gameState = Substitute.For<IGameState>();
            gameState.CurrentCalledOutRank.Returns(Rank.Ten);
            var snapRule = new CallOutSnapRule(gameState);
            var cards = new Cards(new[] {new Card(Suit.Clubs, Rank.Four)});
            
            Assert.That(snapRule.IsSnapValid(cards), Is.False);
        }

        [Test]
        public void SnapIsValid_WhenTheTopCardMatchesTheCallOut()
        {
            var gameState = Substitute.For<IGameState>();
            gameState.CurrentCalledOutRank.Returns(Rank.Four);
            var snapRule = new CallOutSnapRule(gameState);
            var cards = new Cards(new[] {new Card(Suit.Clubs, Rank.Four)});
            
            Assert.That(snapRule.IsSnapValid(cards), Is.True);
        }
    }
}
