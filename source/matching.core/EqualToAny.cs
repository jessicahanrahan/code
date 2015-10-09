using System.Collections.Generic;

namespace code.matching.core
{
  public class EqualToAny<Value> : IMatchAn<Value>
  {
    IList<Value> values;

    public EqualToAny(IEnumerable<Value> values)
    {
      this.values = new List<Value>(values);
    }

    public bool matches(Value item)
    {
      return values.Contains(item);
    }
  }
}