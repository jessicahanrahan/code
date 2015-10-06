using System.Collections.Generic;
using code.prep.movies;

namespace code.matching
{
  public class MatchFactory<Item, AttributeType> : ICreateMatchers<Item, AttributeType>
  {
    IGetAnAttributeValue<Item, AttributeType> accessor;
      IAnonymousMatch<Item> mech; 
    public MatchFactory(IGetAnAttributeValue<Item, AttributeType> accessor, IAnonymousMatch<Item> mech)
    {
      this.accessor = accessor;
        this.mech = mech;
    }

    public IMatchAn<Item> equal_to(AttributeType value)
    {
      return equal_to_any(value);
    }

    public IMatchAn<Item> equal_to_any(params AttributeType[] values)
    {
      return new AnonymousMatch<Item>(x =>
        new List<AttributeType>(values).Contains(accessor(x)));
    }

    public IMatchAn<Item> not_equal_to(AttributeType value)
    {
      return equal_to(value).negate();
    }

  }
}