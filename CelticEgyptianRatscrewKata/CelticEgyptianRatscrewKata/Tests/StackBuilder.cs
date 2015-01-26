using System.Collections.Generic;

namespace CelticEgyptianRatscrewKata.Tests
{
    public class StackBuilder
    {
        private readonly List<Card> cards = new List<Card>();

        public StackBuilder With(Rank rank, Suit suit)
        {
            cards.Add(new Card(suit, rank));
            return this;
        }

        public Stack Build()
        {
            return new Stack(cards);
        }
    }
}
