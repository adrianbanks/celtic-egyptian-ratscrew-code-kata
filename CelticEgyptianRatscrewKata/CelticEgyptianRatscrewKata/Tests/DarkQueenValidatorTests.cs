using CelticEgyptianRatscrewKata.Validators;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    [TestFixture]
    public sealed class DarkQueenValidatorTests
    {
        [Test]
        public void AStackIsNotSnappable_WhenItIsEmpty()
        {
            var stack = new StackBuilder()
                            .Build();
            bool isSnappable = new DarkQueenSnapValidator().IsSnappable(stack);
            Assert.That(isSnappable, Is.False);
        }

        [Test]
        public void AStackIsSnappable_WhenItContainsOnlyTheQueenOfSpades()
        {
            var stack = new StackBuilder()
                            .With(Rank.Queen, Suit.Spades)
                            .Build();
            bool isSnappable = new DarkQueenSnapValidator().IsSnappable(stack);
            Assert.That(isSnappable, Is.True);
        }

        [Test]
        public void AStackIsNotSnappable_WhenItContainsOnlyTheQueenOfDiamonds()
        {
            var stack = new StackBuilder()
                            .With(Rank.Queen, Suit.Diamonds)
                            .Build();
            bool isSnappable = new DarkQueenSnapValidator().IsSnappable(stack);
            Assert.That(isSnappable, Is.False);
        }

        [Test]
        public void AStackIsNotSnappable_WhenItContainsMoreThanOneCard_AndTheTopCardIsNotTheQueenOfSpades()
        {
            var stack = new StackBuilder()
                            .With(Rank.Queen, Suit.Spades)
                            .With(Rank.Eight, Suit.Clubs)
                            .Build();
            bool isSnappable = new DarkQueenSnapValidator().IsSnappable(stack);
            Assert.That(isSnappable, Is.False);
        }

        [Test]
        public void AStackIsSnappable_WhenItContainsMoreThanOneCard_AndTheTopCardIsTheQueenOfSpades()
        {
            var stack = new StackBuilder()
                            .With(Rank.Eight, Suit.Clubs)
                            .With(Rank.Queen, Suit.Spades)
                            .Build();
            bool isSnappable = new DarkQueenSnapValidator().IsSnappable(stack);
            Assert.That(isSnappable, Is.True);
        }
    }
}
