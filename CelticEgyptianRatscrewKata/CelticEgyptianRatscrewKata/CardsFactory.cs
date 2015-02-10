using System;
using System.Linq;

namespace CelticEgyptianRatscrewKata
{
    public class CardsFactory
    {
        public Cards StandardDeck()
        {
            return new Cards(
                ((Rank[]) Enum.GetValues(typeof (Rank))).SelectMany(
                    r => ((Suit[]) Enum.GetValues(typeof (Suit))).Select(s => new Card(s, r)))
                    );
        }
    }
}