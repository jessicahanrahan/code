using System;
using System.Collections.Generic;
using code.matching.core;

namespace code.comparisons
{
  public static class ComparerExtensions
  {
    public static IComparer<Item> then_by<Item, AttributeType>(this IComparer<Item> first,
      IGetAnAttributeValue<Item, AttributeType> accessor) where AttributeType : IComparable<AttributeType>
    {
      return new ChainedComparer<Item>(first, Compare<Item>.by(accessor));
    }

    public static IComparer<Item> reverse<Item>(this IComparer<Item> to_reverse)
    {
      return new ReverseComparer<Item>(to_reverse);
    }
  }
}