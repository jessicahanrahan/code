using System;
using code.core;

namespace code.startup.core
{
  public class Start
  {
    public static ICreateStartupStep create_startup_step = delegate
    {
      throw new NotImplementedException("This needs to be configured by a startup process");
    };

    static IRunAStartupStep create(Type type)
    {
      return create_startup_step(type);
    }

    public static ICreateAStartupPipelineBuilder create_pipeline_builder = () =>
    {
      return new StartupPipelineBuilder(() => {}, create, Delegates.combine_actions);
    };

    public static ISpecifyTheFirstStepInAStartupPipeline by
    {
      get { return create_pipeline_builder(); }
    }
  }
}