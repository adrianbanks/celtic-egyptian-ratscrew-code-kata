using System.Linq;

namespace CelticEgyptianRatscrewKata
{
    public class StandardSnapValidator
    {
        public bool IsSnappable(Stack stack)
        {
            if (stack.Count() != 2)
            {
                return false;
            }

            var firstCard = stack.First();
            var lastCard = stack.Last();

            return firstCard.IsSameRankAs(lastCard);
        }
    }
}