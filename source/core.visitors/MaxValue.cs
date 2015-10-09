using System;
using code.enumerables;

namespace code.core.visitors
{
  public class MaxValue<Scalar> : IProcessAndMaintainState<Scalar, Scalar> where
    Scalar : IComparable<Scalar>
  {
    public Scalar result { get; private set; }

    public void process(Scalar node)
    {
      if (node.CompareTo(result) > 0) result = node;
    }
  }

  class FirstOrDefault<Item> : IProcessAndMaintainState<Item, Item>
  {
    Criteria<Item> condition;
    bool found;

    public FirstOrDefault(Criteria<Item> condition)
    {
      this.condition = condition;
      result = default(Item);
    }

    public void process(Item node)
    {
      if (found) return;
        if (condition(node))
        {
                result = node;
            found = true;
        }
        
    }

    public Item result { get; private set; }
  }
}