namespace code.matching.core
{
  public class NeverMatches<Item> : IMatchAn<Item>
  {
    public static readonly IMatchAn<Item> instance = new NeverMatches<Item>();

    NeverMatches()
    {
    }

    public bool matches(Item item)
    {
      return false;
    }
  }
}