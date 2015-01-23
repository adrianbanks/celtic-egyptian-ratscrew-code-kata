﻿using System.Collections;
using NUnit.Framework;

namespace CelticEgyptianRatscrewKata.Tests
{
    [TestFixture]
    public class SnapTests
    {
        [Test]
        public void NoSnap_WhenThereIsOnlyOneCardPlayed()
        {
            var stack = new Stack(new[] {new Card(Suit.Clubs, Rank.Four)});
            var isValid = IsValidSnap(stack);
            Assert.IsFalse(isValid);
        }

        private static bool IsValidSnap(Stack stack)
        {
            var validator = new StandardSnapValidator();
            bool isValid = validator.Validate(stack);
            return isValid;
        }

        [Test]
        public void Snap_WhenThereIsTwoCardsPlayedOfSameNumber()
        {
            var stack = new Stack(new[] { new Card(Suit.Clubs, Rank.Four), new Card(Suit.Hearts, Rank.Four),  });
            var validator = new StandardSnapValidator();
            bool isValid = validator.Validate(stack);
            Assert.IsTrue(isValid);
        }

        [Test]
        public void NoSnap_WhenThereIsTwoCardsPlayedOfDifferingRank()
        {
            var stack = new Stack(new[] { new Card(Suit.Clubs, Rank.Four), new Card(Suit.Clubs, Rank.Seven), });
            var validator = new StandardSnapValidator();
            bool isValid = validator.Validate(stack);
            Assert.IsFalse(isValid);
        }

        [Test]
        public void Snap_WhenThereIsASandwich()
        {
            var stack = new Stack(new[] { new Card(Suit.Clubs, Rank.Four), new Card(Suit.Clubs, Rank.Seven), new Card(Suit.Clubs, Rank.Four) });
            var validator = new StandardSnapValidator();
            bool isValid = validator.Validate(stack);
            Assert.IsTrue(isValid);
        }

        [Test]
        public void Snap_WhenThereIsASandwichNotOnTop()
        {
            var stack = new Stack(new[]
            {
                new Card(Suit.Clubs, Rank.Ten), 
                new Card(Suit.Clubs, Rank.Three), 
                new Card(Suit.Clubs, Rank.Five), 
                new Card(Suit.Clubs, Rank.Four), 
                new Card(Suit.Clubs, Rank.Seven), 
                new Card(Suit.Clubs, Rank.Four)
            });
            var validator = new StandardSnapValidator();
            bool isValid = validator.Validate(stack);
            Assert.IsTrue(isValid);
        }

        [Test]
        public void Snap_WhenThereIsADarkQueen()
        {
            var stack = new Stack(new[] { new Card(Suit.Spades, Rank.Queen) });
            var validator = new StandardSnapValidator();
            bool isValid = validator.Validate(stack);
            Assert.IsTrue(isValid);
        }

        [Test]
        public void Snap_WhenThereIsADarkQueenOnTop()
        {
            var stack = new Stack(new[] { new Card(Suit.Diamonds, Rank.Ten), new Card(Suit.Spades, Rank.Queen) });
            var validator = new StandardSnapValidator();
            bool isValid = validator.Validate(stack);
            Assert.IsTrue(isValid);
        }

    }
}
