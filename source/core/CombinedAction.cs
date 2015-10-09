using code.startup.core;

namespace code.core
{
  public class CombinedAction : IRunAnAction
  {
    IRun first;
    IRun second;

    public CombinedAction(IRun first, IRun second)
    {
      this.first = first;
      this.second = second;
    }

    public void run()
    {
      first();
      second();
    }
  }
}