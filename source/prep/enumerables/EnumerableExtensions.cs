using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace code.prep.enumerables
{
    public static class EnumerableExtensions 
    {
        public static IEnumerable<Item> one_at_a_time<Item>(this IEnumerable<Item> items)
        {
            foreach (var item in items)
                yield return item;
        }

        public static IEnumerable<Item> all_matching_criteria<Item>(this IEnumerable<Item> items, 
            Criteria<Item> criteria)
        {
            foreach (var item in items)
            {
                if (criteria(item))
                    yield return item;
            }
        }
    }

    public delegate bool Criteria<in Item>(Item item);
}
