using System.Collections.Generic;
using code.enumerables;
using code.prep.movies;
using FluentNHibernate.Testing.Values;

namespace code.matching
{
  public class MatchFactory<Item, AttributeType>
  {
    IGetAnAttributeValue<Item, AttributeType> accessor;

    public MatchFactory(IGetAnAttributeValue<Item, AttributeType> accessor)
    {
      this.accessor = accessor;
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
        return equal_to(value).not();
     }
  }
}