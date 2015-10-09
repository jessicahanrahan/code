using System.Collections.Generic;
using code.matching;
using code.matching.core;

namespace code.comparisons
{
  public class AttributeComparer<Item, AttributeType> : IComparer<Item>
  {
    IGetAnAttributeValue<Item, AttributeType> accessor;
    IComparer<AttributeType> value_comparison;

    public AttributeComparer(IGetAnAttributeValue<Item, AttributeType> accessor, IComparer<AttributeType> value_comparison)
    {
      this.accessor = accessor;
      this.value_comparison = value_comparison;
    }

    public int Compare(Item x, Item y)
    {
      var first_value = accessor(x);
      var second_value = accessor(y);

      return value_comparison.Compare(first_value, second_value);
    }
  }
}