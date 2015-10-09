using System;

namespace code.matching.core
{
  public static class MatchExtensions
  {
    public static IMatchAn<Item> or<Item>(this IMatchAn<Item> left, IMatchAn<Item> right)
    {
     return new OrMatch<Item>(left, right); 
    }

    public static IMatchAn<Item> or<Item,AttributeType>(this IMatchAn<Item> left, IGetAnAttributeValue<Item, AttributeType> accessor,
      Func<MatchCreationExtensionPoint<Item, AttributeType>, IMatchAn<Item>> builder)
    {
      var extension_point = Match<Item>.attribute(accessor);
      var next = builder(extension_point);

      return left.or(next);
    }

    public static IMatchAn<Item> negate<Item>(this IMatchAn<Item> to_negate)
    {
     return new NegatingMatch<Item>(to_negate);
    }
  }
}