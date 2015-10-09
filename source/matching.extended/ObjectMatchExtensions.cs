namespace code.matching.extended
{
  public static class ObjectMatchExtensions
  {
    public static MatchingExtensionPoint<T> is_null<T>(this MatchingExtensionPoint<T> extension) where T : class
    {
      return MatchingExtensionPoint<T>.create_from(x => x == null);
    }

    public static MatchingExtensionPoint<T> equal_to<T>(this MatchingExtensionPoint<T> extension, T value)
    {
      return MatchingExtensionPoint<T>.create_from(x => x.Equals(value));
    }
  }
}