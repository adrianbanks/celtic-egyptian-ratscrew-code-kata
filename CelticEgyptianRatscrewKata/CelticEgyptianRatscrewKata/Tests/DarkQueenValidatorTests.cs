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
    }
}
