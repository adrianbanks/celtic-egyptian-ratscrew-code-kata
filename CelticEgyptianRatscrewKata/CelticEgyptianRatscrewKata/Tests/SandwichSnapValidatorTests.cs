using CelticEgyptianRatscrewKata.Validators;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    [TestFixture]
    public sealed class SandwichSnapValidatorTests
    {
        [Test]
        public void AStackIsNotSnappable_WhenItContainsNoCards()
        {
            var stack = new StackBuilder()
                            .Build();
            bool isSnappable = new SandwichSnapValidator().IsSnappable(stack);
            Assert.That(isSnappable, Is.False);
        }

        [Test]
        public void AStackIsNotSnappable_WhenItContainsOnlyOneCard()
        {
            var stack = new StackBuilder()
                            .With(Rank.Four, Suit.Hearts)
                            .Build();
            bool isSnappable = new SandwichSnapValidator().IsSnappable(stack);
            Assert.That(isSnappable, Is.False);
        }

        [Test]
        public void AStackIsNotSnappable_WhenItContainsOnlyTwoCards()
        {
            var stack = new StackBuilder()
                            .With(Rank.Four, Suit.Hearts)
                            .With(Rank.Three, Suit.Diamonds)
                            .Build();
            bool isSnappable = new SandwichSnapValidator().IsSnappable(stack);
            Assert.That(isSnappable, Is.False);
        }

        [Test]
        public void AStackIsNotSnappable_WhenItContainsEnoughCardsToMakeASandwich_ButDoesNotContainOne()
        {
            var stack = new StackBuilder()
                            .With(Rank.Two, Suit.Clubs)
                            .With(Rank.Ten, Suit.Spades)
                            .With(Rank.Five, Suit.Diamonds)
                            .Build();
            bool isSnappable = new SandwichSnapValidator().IsSnappable(stack);
            Assert.That(isSnappable, Is.False);
        }

        [Test]
        public void AStackIsSnappable_WhenItContainsASandwich()
        {
            var stack = new StackBuilder()
                            .With(Rank.Two, Suit.Clubs)
                            .With(Rank.Ten, Suit.Spades)
                            .With(Rank.Two, Suit.Diamonds)
                            .Build();
            bool isSnappable = new SandwichSnapValidator().IsSnappable(stack);
            Assert.That(isSnappable, Is.True);
        }

        [Test]
        public void AStackIsSnappable_WhenItContainsASandwich_ThatDoesNotStartAtTheBottomOfTheStack()
        {
            var stack = new StackBuilder()
                            .With(Rank.Eight, Suit.Hearts)
                            .With(Rank.Two, Suit.Clubs)
                            .With(Rank.Ten, Suit.Spades)
                            .With(Rank.Two, Suit.Diamonds)
                            .Build();
            bool isSnappable = new SandwichSnapValidator().IsSnappable(stack);
            Assert.That(isSnappable, Is.True);
        }
    }
}
