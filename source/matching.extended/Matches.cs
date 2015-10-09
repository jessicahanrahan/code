namespace code.matching.extended
{
  public class Matches
  {
    public static MatchingExtensionPoint<Target> a<Target>()
    {
      return MatchingExtensionPoint<Target>.always_true;
    }
  }
}