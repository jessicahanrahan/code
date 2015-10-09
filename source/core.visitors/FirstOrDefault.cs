using code.enumerables;

namespace code.core.visitors
{
  public class FirstOrDefault<Item> : IProcessAndMaintainState<Item, Item>
  {
    Criteria<Item> condition;
    bool found;

    public FirstOrDefault(Criteria<Item> condition)
    {
      this.condition = condition;
      result = default(Item);
    }

    public void process(Item node)
    {
      if (found) return;
      if (condition(node))
      {
        found = true;
        result = node;
      }
    }

    public Item result { get; private set; }
  }
}