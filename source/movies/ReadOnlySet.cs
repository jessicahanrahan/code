using System.Collections;
using System.Collections.Generic;

namespace code.movies
{
  public class ReadOnlySet<T> : IEnumerable<T>
  {
    IEnumerable<T> source;

    public ReadOnlySet(IEnumerable<T> source)
    {
      this.source = source;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator()
    {
      return source.GetEnumerator();
    }
  }
}