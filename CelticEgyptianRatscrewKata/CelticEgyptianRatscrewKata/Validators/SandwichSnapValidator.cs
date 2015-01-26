using System.Linq;

namespace CelticEgyptianRatscrewKata.Validators
{
    public class SandwichSnapValidator
    {
        public bool IsSnappable(Stack stack)
        {
            if (stack.Count() < 3)
            {
                return false;
            }

            var nextDoorButOneNeighbourCard = stack.First();
            var nextDoorNeighbourCard = stack.Skip(1).First();

            foreach (var card in stack.Skip(2))
            {
                if (card.IsSameRankAs(nextDoorButOneNeighbourCard))
                {
                    return true;
                }

                nextDoorButOneNeighbourCard = nextDoorNeighbourCard;
                nextDoorNeighbourCard = card;
            }

            return false;
        }
    }
}
