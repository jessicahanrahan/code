namespace code.core
{
  public delegate void IProcessAn<in Element>(Element element);

  public interface IProcess<in Element>
  {
    void process(Element node);
  }

  public interface IProcessAndMaintainState<in Item, out Result> : IProcess<Item>
  {
    Result result { get; }
  }
}