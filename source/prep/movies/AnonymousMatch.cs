using code.enumerables;
using code.matching;

namespace code.prep.movies
{
  public class AnonymousMatch<T> : IMatchAn<T>, IAnonymousMatch<T>
  {
    Criteria<T> criteria;

    public AnonymousMatch(Criteria<T> criteria)
    {
      this.criteria = criteria;
    }

    public bool matches(T item)
    {
      return criteria.Invoke(item);
    }
  }
}