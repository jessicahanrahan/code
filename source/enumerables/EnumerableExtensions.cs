using System;
using System.Collections.Generic;
using code.matching.core;

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

    public static IEnumerable<Item> sort_using<Item>(this IEnumerable<Item> items,
      IComparer<Item> comparison)
    {
      var sorted = new List<Item>(items);
      sorted.Sort(comparison);
      return sorted;
    }

    public static IEnumerable<Item> all_items_matching<Item>(this IEnumerable<Item> items, IMatchAn<Item> criteria)
    {
      return items.all_items_matching(criteria.matches);
    }

    public static IEnumerable<Item> where<Item, AttributeType>(
      this IEnumerable<Item> items,
      IGetAnAttributeValue<Item, AttributeType> accessor,
      ICombineMatchers<Item> combination_strategy,
      params Func<MatchCreationExtensionPoint<Item, AttributeType>, IMatchAn<Item>>[] match_builders)
    {
      var extension_point = Match<Item>.attribute(accessor);
      IMatchAn<Item> criteria = NeverMatches<Item>.instance;

      foreach (var match_builder in match_builders)
      {
        var match = match_builder(extension_point);
        criteria = combination_strategy(criteria, match);
      }

      return items.all_items_matching(criteria);
    }
  }
}