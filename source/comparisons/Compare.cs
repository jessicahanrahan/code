using System;
using System.Collections.Generic;
using code.matching;
using code.matching.core;

namespace code.comparisons
{
  public class Compare<Item>
  {
    public static IComparer<Item> by_descending<AttributeType>(IGetAnAttributeValue<Item, AttributeType> accessor)
      where AttributeType : IComparable<AttributeType>
    {
      return new ReverseComparer<Item>(by(accessor));
    }

    public static IComparer<Item> by<AttributeType>(IGetAnAttributeValue<Item, AttributeType> accessor)
      where AttributeType : IComparable<AttributeType>
    {
      return new AttributeComparer<Item,AttributeType>(accessor, 
        new ComparableComparer<AttributeType>());
    }

    public static IComparer<Item> by<AttributeType>(IGetAnAttributeValue<Item, AttributeType> accessor, IApplyASortDirection direction)
      where AttributeType : IComparable<AttributeType>
    {
      var comparison = by(accessor);

      return direction.apply_to(comparison);
    }

    public static IComparer<Item> by<AttributeType>(IGetAnAttributeValue<Item, AttributeType> accessor,
      params AttributeType[] order)
    {
      return new AttributeComparer<Item,AttributeType>(accessor, new FixedComparer<AttributeType>(order));
    }
  }
}