using System.Linq;

namespace CelticEgyptianRatscrewKata
{
    public class StandardSnapValidator
    {
        public bool Validate(Stack stack)
        {
            if (IsDarkQueenSnap(stack)) return true;

            if (stack.Count() > 1)
            {
                Card cardBeforeLast = stack.First();
                Card previousCard = stack.Skip(1).First();

                if (StandardSnap(cardBeforeLast, previousCard)) return true;

                foreach (var card in stack.Skip(2))
                {
                    if (StandardSnap(previousCard, card) || Sandwich(cardBeforeLast, card))
                    {
                        return true;
                    }
                    cardBeforeLast = previousCard;
                    previousCard = card;
                }
            }

            return false;
        }

        private static bool StandardSnap(Card card1, Card card2)
        {
            return (card1.Rank == card2.Rank);
        }

        private static bool Sandwich(Card card1, Card card3)
        {
            return (card1.Rank == card3.Rank);
        }

        private readonly Card DarkQueen = new Card(Suit.Spades, Rank.Queen);

        private bool IsDarkQueenSnap(Stack stack)
        {
            if (stack.Any())
            {
                var topCard = stack.Last();

                if (topCard.Equals(DarkQueen))
                {
                    return true;
                }
            }
            return false;
        }
    }
}