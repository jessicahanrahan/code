using System;

namespace code.matching.extended
{
  public static class ComparableMatchExtensions
  {
    public static MatchingExtensionPoint<T> less_than<T>(this MatchingExtensionPoint<T> extension, T value)
      where T : IComparable<T>
    {
      return MatchingExtensionPoint<T>.create_from(x => x.CompareTo(value) < 0);
    }

    public static MatchingExtensionPoint<T> greater_than<T>(this MatchingExtensionPoint<T> extension, T value)
      where T : IComparable<T>
    {
      return MatchingExtensionPoint<T>.create_from(x => x.CompareTo(value) > 0);
    }

    public static MatchingExtensionPoint<T> greater_than_or_equal_to<T>(this MatchingExtensionPoint<T> extension,
      T value) where T : IComparable<T>
    {
      return extension.greater_than(value).or(x => x.equal_to(value));
    }

    public static MatchingExtensionPoint<T> less_than_or_equal_to<T>(this MatchingExtensionPoint<T> extension, T value)
      where T : IComparable<T>
    {
      return extension.less_than(value).or(x => x.equal_to(value));
    }
  }
}