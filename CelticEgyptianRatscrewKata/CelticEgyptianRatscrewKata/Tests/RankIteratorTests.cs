using CelticEgyptianRatscrewKata.Game;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    [TestFixture]
    public sealed class RankIteratorTests
    {
        [Test]
        public void TestIteratorStartsAtAceAndIncrements()
        {
            var iterator = new RankIterator();
            var first = iterator.GetNext();
            Assert.That(first, Is.EqualTo(Rank.Ace));
            var second = iterator.GetNext();
            Assert.That(second, Is.EqualTo(Rank.Two));
        }

        [Test]
        public void TestIteratorCyclesRoundCorrectly()
        {
            var iterator = new RankIterator(Rank.King);
            var first = iterator.GetNext();
            Assert.That(first, Is.EqualTo(Rank.King));
            var second = iterator.GetNext();
            Assert.That(second, Is.EqualTo(Rank.Ace));
        }
    }
}
