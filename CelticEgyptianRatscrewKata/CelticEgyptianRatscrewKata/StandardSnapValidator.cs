using System.Linq;

namespace CelticEgyptianRatscrewKata
{
    public class StandardSnapValidator
    {
        public bool Validate(Stack stack)
        {
            if (stack.Count() > 1)
            {
                Card oldCard = stack.First();
                foreach (var card in stack.Skip(1))
                {
                    if (oldCard.Rank == card.Rank)
                    {
                        return true;
                    }
                    oldCard = card;
                }
            }
            return false;
        }
    }
}