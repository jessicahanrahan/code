using System;
using code.ranges;

namespace code.matching.core
{
  public class FallsInRange<Value> : IMatchAn<Value> where Value : IComparable<Value>
  {
    IContainValues<Value> range;

    public FallsInRange(IContainValues<Value> range)
    {
      this.range = range;
    }

    public bool matches(Value item)
    {
      return range.contains(item);
    }
  }
}