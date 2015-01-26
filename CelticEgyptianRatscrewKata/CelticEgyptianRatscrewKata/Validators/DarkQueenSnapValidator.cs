using System.Linq;

namespace CelticEgyptianRatscrewKata.Validators
{
    public class DarkQueenSnapValidator
    {
        private readonly Card darkQueenCard = new Card(Suit.Spades, Rank.Queen);

        public bool IsSnappable(Stack stack)
        {
            var card = stack.LastOrDefault();
            return darkQueenCard.Equals(card);
        }
    }
}
