using System.Linq;

namespace CelticEgyptianRatscrewKata
{
    public class SandwichSnapValidator
    {
        public bool IsSnappable(Stack stack)
        {
            if (stack.Count() < 3)
            {
                return false;
            }

            var firstCard = stack.First();
            var lastCard = stack.Last();
            return firstCard.IsSameRankAs(lastCard);
        }
    }
}
