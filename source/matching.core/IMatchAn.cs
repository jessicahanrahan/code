namespace code.matching.core
{
  public interface IMatchAn<in Item>
  {
    bool matches(Item item);
  }
}