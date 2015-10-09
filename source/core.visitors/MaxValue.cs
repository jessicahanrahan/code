using System;

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
}