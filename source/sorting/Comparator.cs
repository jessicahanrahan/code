using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using code.matching;

namespace code.sorting
{
    class Comparator<ItemToCompare, AttributeType>
    {
        IGetAnAttributeValue<ItemToCompare, AttributeType> accessor;

        public static void sort_by(Func<object, object> func)
        {
            throw new NotImplementedException();
        }
    }
}
