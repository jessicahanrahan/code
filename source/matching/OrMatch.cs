namespace code.matching
{
  public class OrMatch<Item> : IMatchAn<Item>
  {
    IMatchAn<Item> left;
    IMatchAn<Item> right;

    public OrMatch(IMatchAn<Item> left, IMatchAn<Item> right)
    {
      this.left = left;
      this.right = right;
    }

    public bool matches(Item item)
    {
      return left.matches(item) || right.matches(item);
    }
  }

    public class NotMatch<Item> : IMatchAn<Item>
    {
        IMatchAn<Item> to_negate;

        public NotMatch(IMatchAn<Item> to_negate)
        {
            this.to_negate = to_negate;
        }

        public bool matches(Item item)
        {
            return !to_negate.matches(item);
        }
    }
}