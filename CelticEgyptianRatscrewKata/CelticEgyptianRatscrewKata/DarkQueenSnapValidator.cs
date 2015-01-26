using System.Linq;

namespace CelticEgyptianRatscrewKata
{
    public class DarkQueenSnapValidator
    {
        public bool IsSnappable(Stack stack)
        {
            return stack.Count() == 1;
        }
    }
}
