using System;
using System.Security.Cryptography.X509Certificates;
using code.enumerables;
using code.ranges;

namespace code.matching
{
  public static class MatchCreationExtensions
  {
    public static IMatchAn<Item> equal_to<Item, AttributeType>(
      this MatchCreationExtensionPoint<Item, AttributeType> extension_point, AttributeType value)
    {
      return equal_to_any(extension_point, value);
    }

    public static IMatchAn<Item> equal_to_any<Item, AttributeType>(
      this MatchCreationExtensionPoint<Item, AttributeType> extension_point, params AttributeType[] values)
    {
      return create_from_match(extension_point, new EqualToAny<AttributeType>(values));
    }

    public static IMatchAn<Item> not_equal_to<Item, AttributeType>(
      this MatchCreationExtensionPoint<Item, AttributeType> extension_point, AttributeType value)
    {
      return equal_to(extension_point, value).negate();
    }

    public static IMatchAn<Item> create_from_criteria<Item, AttributeType>(
      this MatchCreationExtensionPoint<Item, AttributeType> extension_point, Criteria<Item> criteria)
    {
      return new AnonymousMatch<Item>(criteria);
    }

    public static IMatchAn<Item> create_from_match<Item, AttributeType>(
      this MatchCreationExtensionPoint<Item, AttributeType> extension_point, IMatchAn<AttributeType> value_matcher)
    {
      return new AttributeMatch<Item, AttributeType>(extension_point.accessor,
        value_matcher);
    }

    public static IMatchAn<Item> greater_than<Item, AttributeType>(
      this MatchCreationExtensionPoint<Item, AttributeType> extension_point, AttributeType value)
      where AttributeType : IComparable<AttributeType>
    {
      return falls_in_range(extension_point, new RangeWithNoUpperBound<AttributeType>(value));
    }

    public static IMatchAn<Item> between<Item, AttributeType>(
      this MatchCreationExtensionPoint<Item, AttributeType> extension_point, AttributeType start, AttributeType end)
      where AttributeType : IComparable<AttributeType>
    {
      return falls_in_range(extension_point, new InclusiveRange<AttributeType>(start, end));
    }


        public static IMatchAn<Item> falls_in_range<Item, AttributeType>(
      this MatchCreationExtensionPoint<Item, AttributeType> extension_point, IContainValues<AttributeType> range)
      where AttributeType : IComparable<AttributeType>
    {
      return create_from_match(extension_point, new FallsInRange<AttributeType>(range));
    }
  }

    public static class DateMatchCreationExtensions
{
    
     public static IMatchAn<Item> year_is_between<Item>(
          this MatchCreationExtensionPoint<Item, DateTime> extension_point, int start, int end)
    {
            return extension_point.create_from_match(Match<DateTime>.attribute(x => x.Year).between(start, end));
    }

}
}