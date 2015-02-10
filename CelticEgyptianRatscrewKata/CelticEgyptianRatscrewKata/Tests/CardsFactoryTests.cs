using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    [TestFixture]
    class CardsFactoryTests
    {
        [Test]
        public void AStandardDeckHas52Cards()
        {
            var deck = new CardsFactory().StandardDeck();
            Assert.That(deck.Count(), Is.EqualTo(52));
        }
    }
}
