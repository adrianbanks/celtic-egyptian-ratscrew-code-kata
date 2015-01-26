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
    }
}
