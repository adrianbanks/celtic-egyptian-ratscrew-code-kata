using System.Linq;

namespace CelticEgyptianRatscrewKata
{
    public class StandardSnapValidator
    {
        public bool Validate(Stack stack)
        {
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
    }
}