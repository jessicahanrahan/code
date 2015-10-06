using System.Collections.Generic;
using code.enumerables;
using code.prep.movies;
using Machine.Specifications;
using NHibernate.Exceptions;

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
            //IMatchAn<Item> retVal = NeverMatches<Item>.instance;
            //foreach (AttributeType val in values)
            //{
            //    retVal = retVal.or(equal_to(val));
            //}

            //return retVal;

            return new AnonymousMatch<Item>(x => new List<AttributeType>(values).Contains(accessor(x)));
    }

      public IMatchAn<Item> not_equal_to(AttributeType value)
      {
          return new AnonymousMatch<Item>(x => accessor(x).Equals(value));
      } 
  }

    public class NeverMatches<Item> : IMatchAn<Item>
    {
        public static readonly IMatchAn<Item> instance = new NeverMatches<Item>();
        
        NeverMatches() { }
        
        public bool matches(Item item)
        {
            return false;
        }  
    }
}