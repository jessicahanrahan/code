using code.core;

namespace code.startup.core
{
  public interface ISpecifyTheFirstStepInAStartupPipeline
  {
    IAddExtraStepsToAStartupPipeline running<Step>() where Step : IRunAStartupStep;
    IAddExtraStepsToAStartupPipeline running(IRun action);
    IAddExtraStepsToAStartupPipeline initializing_with(IRun action);
    void only_running<Step>() where Step : IRunAStartupStep;
  }

  public interface IAddExtraStepsToAStartupPipeline
  {
    IAddExtraStepsToAStartupPipeline then<Step>() where Step : IRunAStartupStep;
    void finish_with<Step>() where Step : IRunAStartupStep;
  }
}