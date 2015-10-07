using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using code.matching;

namespace code.sorting
{
    public class Comparator<ItemToCompare, AttributeType>
    {
        IGetAnAttributeValue<ItemToCompare, AttributeType> accessor;

        public Comparator(IGetAnAttributeValue<ItemToCompare, AttributeType> accessor)
        {
            this.accessor = accessor;
        }

        public static void sort_by(Func<object, object> func)
        {
            throw new NotImplementedException();
        }
    }
}
