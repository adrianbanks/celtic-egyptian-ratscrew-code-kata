using System.Linq;

namespace CelticEgyptianRatscrewKata
{
    public class DarkQueenSnapValidator
    {
        private readonly Card queenOfSpades = new Card(Suit.Spades, Rank.Queen);

        public bool IsSnappable(Stack stack)
        {
            var card = stack.LastOrDefault();
            return queenOfSpades.Equals(card);
        }
    }
}
