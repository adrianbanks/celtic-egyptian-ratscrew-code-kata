using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    [TestFixture]
    public sealed class DarkQueenValidatorTests
    {
        [Test]
        public void AStackIsNotSnappable_WhenItIsEmpty()
        {
            var stack = new Stack(new Card[0]);
            bool isSnappable = new DarkQueenSnapValidator().IsSnappable(stack);
            Assert.That(isSnappable, Is.False);
        }

        [Test]
        public void AStackIsSnappable_WhenItContainsOnlyTheQueenOfSpades()
        {
            var stack = new Stack(new[] {new Card(Suit.Spades, Rank.Queen) });
            bool isSnappable = new DarkQueenSnapValidator().IsSnappable(stack);
            Assert.That(isSnappable, Is.True);
        }

        [Test]
        public void AStackIsNotSnappable_WhenItContainsOnlyTheQueenOfDiamonds()
        {
            var stack = new Stack(new[] {new Card(Suit.Diamonds, Rank.Queen) });
            bool isSnappable = new DarkQueenSnapValidator().IsSnappable(stack);
            Assert.That(isSnappable, Is.False);
        }
    }
}
