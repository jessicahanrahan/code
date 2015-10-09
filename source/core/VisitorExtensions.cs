using System.Collections.Generic;

namespace code.core
{
  public static class VisitorExtensions
  {
    public static void each<Element>(this IEnumerable<Element> items,
      IProcessAn<Element> visitor)
    {
      foreach (var item in items) visitor(item);
    }
  }
}