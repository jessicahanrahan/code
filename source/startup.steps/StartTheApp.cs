using code.startup.core;

namespace code.startup.steps
{
  public static class StartTheApp
  {
    public static void run()
    {
      Start.by.initializing_with(MinimalInitialConfiguration.run)
        .finish_with<NonAction>();
    }
  }

  public class NonAction : IRunAStartupStep
  {
    public void run()
    {
    }
  }
}