using System;
using code.enumerables;
using code.ranges;

namespace code.matching.core
{
  public static class MatchCreationExtensions
  {
    public static IMatchAn<Item> equal_to<Item, AttributeType>(
      this IProvideAccessToCreateMatchers<Item, AttributeType> extension_point, AttributeType value)
    {
      return equal_to_any(extension_point, value);
    }

    public static IMatchAn<Item> equal_to_any<Item, AttributeType>(
      this IProvideAccessToCreateMatchers<Item, AttributeType> extension_point, params AttributeType[] values)
    {
      return create_from_match(extension_point, new EqualToAny<AttributeType>(values));
    }

    public static IMatchAn<Item> not_equal_to<Item, AttributeType>(
      this IProvideAccessToCreateMatchers<Item, AttributeType> extension_point, AttributeType value)
    {
      return equal_to(extension_point, value).negate();
    }

    public static IMatchAn<Item> create_from_criteria<Item, AttributeType>(
      this IProvideAccessToCreateMatchers<Item, AttributeType> extension_point, Criteria<Item> criteria)
    {
      return new AnonymousMatch<Item>(criteria);
    }


    public static IMatchAn<Item> create_from_match<Item, AttributeType>(
      this IProvideAccessToCreateMatchers<Item, AttributeType> extension_point, IMatchAn<AttributeType> value_matcher)
    {
      return extension_point.create_matcher(value_matcher);
    }

    public static IMatchAn<Item> greater_than<Item, AttributeType>(
      this IProvideAccessToCreateMatchers<Item, AttributeType> extension_point, AttributeType value)
      where AttributeType : IComparable<AttributeType>
    {
      return falls_in_range(extension_point, new RangeWithNoUpperBound<AttributeType>(value));
    }

    public static IMatchAn<Item> between<Item, AttributeType>(
      this IProvideAccessToCreateMatchers<Item, AttributeType> extension_point, AttributeType start, AttributeType end)
      where AttributeType : IComparable<AttributeType>
    {
      return falls_in_range(extension_point, new InclusiveRange<AttributeType>(start, end));
    }

    public static IMatchAn<Item> falls_in_range<Item, AttributeType>(
      this IProvideAccessToCreateMatchers<Item, AttributeType> extension_point, IContainValues<AttributeType> range)
      where AttributeType : IComparable<AttributeType>
    {
      return create_from_match(extension_point, new FallsInRange<AttributeType>(range));
    }
  }
}
