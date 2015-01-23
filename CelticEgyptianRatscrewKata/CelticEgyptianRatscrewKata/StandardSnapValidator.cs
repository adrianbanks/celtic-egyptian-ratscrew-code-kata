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

                if (cardBeforeLast.Rank == previousCard.Rank)
                {
                    return true;
                }

                foreach (var card in stack.Skip(2))
                {
                    if (card.Rank == previousCard.Rank || cardBeforeLast.Rank == card.Rank)
                    {
                        return true;
                    }
                    cardBeforeLast = previousCard;
                    previousCard = card;
                }
            }

            return false;
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