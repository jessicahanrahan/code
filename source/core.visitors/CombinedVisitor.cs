namespace code.core
{
  public class CombinedVisitor<Item> : IProcess<Item>
  {
    IProcess<Item> first;
    IProcess<Item> second;

    public CombinedVisitor(IProcess<Item> first, IProcess<Item> second)
    {
      this.first = first;
      this.second = second;
    }

    public void process(Item node)
    {
      first.process(node);
      second.process(node);
    }
  }
}