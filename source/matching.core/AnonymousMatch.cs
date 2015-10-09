using code.enumerables;

namespace code.matching.core
{
  public class AnonymousMatch<T> : IMatchAn<T>
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