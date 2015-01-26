using System.Linq;

namespace CelticEgyptianRatscrewKata.Validators
{
    public class StandardSnapValidator
    {
        public bool IsSnappable(Stack stack)
        {
            if (stack.Count() < 2)
            {
                return false;
            }

            var previousCard = stack.First();

            foreach (var card in stack.Skip(1))
            {
                if (card.IsSameRankAs(previousCard))
                {
                    return true;
                }

                previousCard = card;
            }

            return false;
        }
    }
}