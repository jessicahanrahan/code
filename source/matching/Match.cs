using System;

namespace code.matching
{
  public class Match<Item>
  {
    public static MatchFactory<Item, AttributeType> attribute<AttributeType>(
      IGetAnAttributeValue<Item, AttributeType> accessor)
    {
      return new MatchFactory<Item, AttributeType>(accessor);
    }

    public static ComparableMatchFactory<Item, AttributeType> comparable_attribute<AttributeType>(
      IGetAnAttributeValue<Item, AttributeType> accessor) where AttributeType : IComparable<AttributeType>
    {
      return new ComparableMatchFactory<Item, AttributeType>(accessor,
          attribute(accessor));
    }
  }
}