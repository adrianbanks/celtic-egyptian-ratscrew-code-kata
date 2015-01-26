using System.Linq;

namespace CelticEgyptianRatscrewKata
{
    public class DarkQueenSnapValidator
    {
        public bool IsSnappable(Stack stack)
        {
            var card = stack.FirstOrDefault();
            return new Card(Suit.Spades, Rank.Queen).Equals(card);
        }
    }
}
