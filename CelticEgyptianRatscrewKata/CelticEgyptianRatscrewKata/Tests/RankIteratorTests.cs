using CelticEgyptianRatscrewKata.Game;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    [TestFixture]
    public sealed class RankIteratorTests
    {
        [Test]
        public void IteratorStartsAtSpecifiedRank()
        {
            var iterator = new RankIterator(startingRank: Rank.Ace);
            Assert.That(iterator.Current, Is.EqualTo(Rank.Ace));
        }

        [Test]
        public void TestIteratorStartsAtAceAndIncrements()
        {
            var iterator = new RankIterator(startingRank: Rank.Ace);
            iterator.MoveNext();
            Assert.That(iterator.Current, Is.EqualTo(Rank.Two));
        }

        [Test]
        public void TestIteratorCyclesRoundCorrectly()
        {
            var iterator = new RankIterator(startingRank: Rank.King);
            iterator.MoveNext();
            Assert.That(iterator.Current, Is.EqualTo(Rank.Ace));
        }
    }
}
