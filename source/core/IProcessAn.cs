namespace code.core
{
  public delegate void IProcessAn<in Element>(Element element);

  public interface IProcess<in Element>
  {
    void process(Element node); 
  }

  public interface IProcessAndMaintainState<in Element, out StepState> : IProcess<Element>
  {
    StepState state { get; } 
  }
}