using System;
using code.enumerables;
using code.prep.movies;

namespace code.matching
{
  public class ComparableMatchFactory<Item, AttributeType> : ICreateMatchers<Item, AttributeType>
    where AttributeType : IComparable<AttributeType>
  {
    IGetAnAttributeValue<Item, AttributeType> accessor;
    ICreateMatchers<Item, AttributeType> original; 

    public ComparableMatchFactory(IGetAnAttributeValue<Item, AttributeType> accessor, 
        ICreateMatchers<Item, AttributeType> original)
    {
      this.accessor = accessor;
        this.original = original;
    }

    public IMatchAn<Item> greater_than(AttributeType value)
    {
      return new AnonymousMatch<Item>(x => accessor(x).CompareTo(value) > 0);
    }

    public IMatchAn<Item> between(AttributeType start, AttributeType end)
    {
      return new AnonymousMatch<Item>(x => accessor(x).CompareTo(start) >= 0 &&
      accessor(x).CompareTo(end) <=0);
    }

      public IMatchAn<Item> equal_to(AttributeType value)
      {
          return original.equal_to(value);
      }

      public IMatchAn<Item> equal_to_any(params AttributeType[] values)
      {
          return original.equal_to_any(values);
      }

      public IMatchAn<Item> not_equal_to(AttributeType value)
      {
          return original.not_equal_to(value);
      }
  }
}