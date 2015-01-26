using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    [TestFixture]
    public sealed class StandardSnapValidatorTests
    {
        [Test]
        public void AStackIsNotIsSnappable_WhenItIsEmpty()
        {
            var stack = new Stack(new Card[0]);
            bool isSnappable = new StandardSnapValidator().IsSnappable(stack);
            Assert.That(isSnappable, Is.False);
        }

        [Test]
        public void AStackIsNotSnappable_WhenItContainsOnlyOneCard()
        {
            var stack = new Stack(new[] {new Card(Suit.Clubs, Rank.Eight) });
            bool isSnappable = new StandardSnapValidator().IsSnappable(stack);
            Assert.That(isSnappable, Is.False);
        }

        [Test]
        public void AStackIsSnappable_WhenItContainsTwoCards_WithMatchingRanks()
        {
            var stack = new Stack(new[] { new Card(Suit.Clubs, Rank.Eight), new Card(Suit.Diamonds, Rank.Eight) });
            bool isSnappable = new StandardSnapValidator().IsSnappable(stack);
            Assert.That(isSnappable, Is.True);
        }

        [Test]
        public void AStackIsSnappable_WhenItContainsTwoCards_WithNonMatchingRanks()
        {
            var stack = new Stack(new[] { new Card(Suit.Clubs, Rank.Two), new Card(Suit.Diamonds, Rank.Eight) });
            bool isSnappable = new StandardSnapValidator().IsSnappable(stack);
            Assert.That(isSnappable, Is.False);
        }
    }
}
