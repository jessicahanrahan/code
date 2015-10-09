namespace code.matching.core
{
  public class match_combinations
  {
    public static ICombineMatchers<Item> or<Item>()
    {
      return (left, right) => left.or(right);
    }
  }
}