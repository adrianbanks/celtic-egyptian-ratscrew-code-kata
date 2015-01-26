using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    [TestFixture]
    public sealed class StandardSnapValidatorTests
    {
        [Test]
        public void IsSnappable_ReturnsFalse_WhenTheStackIsEmpty()
        {
            var stack = new Stack(new Card[0]);
            var snapValidator = new StandardSnapValidator();
            bool isSnappable = snapValidator.IsSnappable(stack);
            Assert.That(isSnappable, Is.False);
        }

        [Test]
        public void IsSnappable_ReturnsFalse_WhenTheStackContainsOnlyOneCard()
        {
            var stack = new Stack(new[] {new Card(Suit.Clubs, Rank.Eight) });
            var snapValidator = new StandardSnapValidator();
            bool isSnappable = snapValidator.IsSnappable(stack);
            Assert.That(isSnappable, Is.False);
        }

        [Test]
        public void IsSnappable_ReturnsTrue_WhenThereIsAMatchingAdjacentRank()
        {
            var stack = new Stack(new[] { new Card(Suit.Clubs, Rank.Eight), new Card(Suit.Diamonds, Rank.Eight) });
            var snapValidator = new StandardSnapValidator();
            bool isSnappable = snapValidator.IsSnappable(stack);
            Assert.That(isSnappable, Is.True);
        }
    }
}
