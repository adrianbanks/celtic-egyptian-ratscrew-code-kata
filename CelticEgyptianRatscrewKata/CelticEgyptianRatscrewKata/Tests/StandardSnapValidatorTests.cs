using CelticEgyptianRatscrewKata.Validators;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    [TestFixture]
    public sealed class StandardSnapValidatorTests
    {
        [Test]
        public void AStackIsNotIsSnappable_WhenItIsEmpty()
        {
            var stack = new StackBuilder()
                            .Build();
            bool isSnappable = new StandardSnapValidator().IsSnappable(stack);
            Assert.That(isSnappable, Is.False);
        }

        [Test]
        public void AStackIsNotSnappable_WhenItContainsOnlyOneCard()
        {
            var stack = new StackBuilder()
                            .With(Rank.Eight, Suit.Clubs)
                            .Build();
            bool isSnappable = new StandardSnapValidator().IsSnappable(stack);
            Assert.That(isSnappable, Is.False);
        }

        [Test]
        public void AStackIsSnappable_WhenItContainsTwoCards_WithMatchingRanks()
        {
            var stack = new StackBuilder()
                            .With(Rank.Eight, Suit.Clubs)
                            .With(Rank.Eight, Suit.Diamonds)
                            .Build();
            bool isSnappable = new StandardSnapValidator().IsSnappable(stack);
            Assert.That(isSnappable, Is.True);
        }

        [Test]
        public void AStackIsSnappable_WhenItContainsTwoCards_WithNonMatchingRanks()
        {
            var stack = new StackBuilder()
                            .With(Rank.Two, Suit.Clubs)
                            .With(Rank.Eight, Suit.Diamonds)
                            .Build();
            bool isSnappable = new StandardSnapValidator().IsSnappable(stack);
            Assert.That(isSnappable, Is.False);
        }

        [Test]
        public void AStackIsNotSnappable_WhenItContainsThreeCards_WithNoMatchingAdjacentRanks()
        {
            var stack = new StackBuilder()
                            .With(Rank.Two, Suit.Clubs)
                            .With(Rank.Eight, Suit.Diamonds)
                            .With(Rank.Two, Suit.Diamonds)
                            .Build();
            bool isSnappable = new StandardSnapValidator().IsSnappable(stack);
            Assert.That(isSnappable, Is.False);
        }

        [Test]
        public void AStackIsSnappable_WhenItContainsThreeCards_WithMatchingAdjacentRanks()
        {
            var stack = new StackBuilder()
                            .With(Rank.Two, Suit.Clubs)
                            .With(Rank.Eight, Suit.Diamonds)
                            .With(Rank.Eight, Suit.Clubs)
                            .Build();
            bool isSnappable = new StandardSnapValidator().IsSnappable(stack);
            Assert.That(isSnappable, Is.True);
        }
    }
}
