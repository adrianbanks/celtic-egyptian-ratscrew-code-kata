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
    }
}
