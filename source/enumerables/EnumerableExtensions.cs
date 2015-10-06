using System.Collections.Generic;
using code.prep.movies;

namespace code.enumerables
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<Item> one_at_a_time<Item>(this IEnumerable<Item> items)
        {
            foreach (var item in items)
                yield return item;
        }

        public static IEnumerable<Item> all_items_matching<Item>(this IEnumerable<Item> items, Criteria<Item> criteria)
        {
            foreach (var item in items)
            {
                if (criteria(item))
                    yield return item;
            }
        }

        public static IEnumerable<Item> all_items_matching<Item>(this IEnumerable<Item> items, IMatch<Item> criteria)
        {
            return items.all_items_matching(criteria.matches);
        }
    }
}