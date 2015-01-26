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
    }

    public class SandwichSnapValidator
    {
        public bool IsSnappable(Stack stack)
        {
            return false;
        }
    }
}
