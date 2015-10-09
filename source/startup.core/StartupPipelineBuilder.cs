using code.core;

namespace code.startup.core
{
  public class StartupPipelineBuilder : ISpecifyTheFirstStepInAStartupPipeline,
    IAddExtraStepsToAStartupPipeline
  {
    public IRun step;
    ICreateStartupStep step_factory;
    ICombineActions combine_actions;

    public StartupPipelineBuilder(IRun step, ICreateStartupStep step_factory, ICombineActions combine_actions)
    {
      this.step = step;
      this.step_factory = step_factory;
      this.combine_actions = combine_actions;
    }

    public IAddExtraStepsToAStartupPipeline initializing_with(IRun action)
    {
      action();
      return running(() => { });
    }

    public IAddExtraStepsToAStartupPipeline running(IRun action)
    {
      return new StartupPipelineBuilder(combine_actions(step, action), step_factory, combine_actions);
    }

    public IAddExtraStepsToAStartupPipeline running<Step>() where Step : IRunAStartupStep
    {
      return combine_with<Step>();
    }

    public void only_running<Step>() where Step : IRunAStartupStep
    {
      step_factory(typeof(Step)).run();
    }

    IAddExtraStepsToAStartupPipeline combine_with<Step>() where Step : IRunAStartupStep
    {
      var new_step = step_factory(typeof(Step));
      return running(new_step.run);
    }

    public IAddExtraStepsToAStartupPipeline then<Step>() where Step : IRunAStartupStep
    {
      return combine_with<Step>();
    }

    public void finish_with<Step>() where Step : IRunAStartupStep
    {
      var last_step = step_factory(typeof(Step));

      combine_actions(step, last_step.run)();
    }
  }
}