using System.Collections.Generic;
using code.prep.movies;

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
      return new AnonymousMatch<Item>(x => accessor(x).Equals(value));
    }

    public IMatchAn<Item> equal_to_any(params AttributeType[] values)
    {
        IList<IMatchAn<Item>> match_list = new List<IMatchAn<Item>>();
        IMatchAn<Item> retVal = null;
        foreach (AttributeType val in values)
        {
             match_list.Add(equal_to(val));
        }
            
            //get iMatchans
            //then use OrMatch between them to build 1 imatcha
        return ;
    }
  }
}