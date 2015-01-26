using System.Linq;

namespace CelticEgyptianRatscrewKata
{
    public class StandardSnapValidator
    {
        public bool IsSnappable(Stack stack)
        {
            return stack.Count() == 2;
        }
    }
}