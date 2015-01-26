using System.Linq;

namespace CelticEgyptianRatscrewKata
{
    public class SandwichSnapValidator
    {
        public bool IsSnappable(Stack stack)
        {
            return stack.Count() >= 2;
        }
    }
}
