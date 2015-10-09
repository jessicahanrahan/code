using System.Collections;
using System.Collections.Generic;
using code.matching;
using code.matching.core;

namespace code.enumerables
{
  public class ConstrainedEnumerable<Item> : IEnumerable<Item>
  {
    IMatchAn<Item> constraint;
    IEnumerable<Item> items;

    public ConstrainedEnumerable(IMatchAn<Item> constraint, IEnumerable<Item> items)
    {
      this.constraint = constraint;
      this.items = items;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<Item> GetEnumerator()
    {
      return items.all_items_matching(constraint).GetEnumerator();
    }
  }
}