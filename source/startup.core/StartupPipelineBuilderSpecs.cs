using System;
using System.Collections.Generic;
using code.core;
using developwithpassion.specification.adapters.rhino_mocks;
using developwithpassion.specifications.assertions;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.should;
using Machine.Specifications;

namespace code.startup.core

{
  [Subject(typeof(StartupPipelineBuilder))]
  public class StartupPipelineBuilderSpecs
  {
    public abstract class concern_for_initial_step : spec.observe<ISpecifyTheFirstStepInAStartupPipeline,
      StartupPipelineBuilder>
    {
    }

    public class when_initializing_with_an_action : concern_for_initial_step
    {
       Establish c = () =>
      {
        the_action = () =>
        {
          ran = true;

        };
      };

      Because b = () =>
        result = sut.initializing_with(the_action);

      It runs_the_intialization_step = () =>
        ran.ShouldBeTrue();

      It allows_the_client_to_continue_adding_steps_to_the_pipeline = () =>
      {
        result.ShouldBeAssignableTo<IAddExtraStepsToAStartupPipeline>();
        result.Equals(sut).ShouldBeFalse();
      };

      static IAddExtraStepsToAStartupPipeline result;
      static IRun the_action;
      static bool ran;
    }
    public class when_an_action_is_specified : concern_for_initial_step
    {
       Establish c = () =>
      {
        the_action = () =>
        {

        };
        combined_step = () =>
        {
        };

        depends.on<ICombineActions>((first, second) =>
        {
          second.ShouldEqual(the_action);
          return combined_step;
        });
      };

      Because b = () =>
        result = sut.running(the_action);

      It returns_a_new_builder_with_the_first_step_created = () =>
        result.downcast_to<StartupPipelineBuilder>().step.ShouldEqual(combined_step);

      It allows_the_client_to_continue_adding_steps_to_the_pipeline = () =>
      {
        result.ShouldBeAssignableTo<IAddExtraStepsToAStartupPipeline>();
        result.Equals(sut).ShouldBeFalse();
        result.downcast_to<StartupPipelineBuilder>().step.ShouldEqual(combined_step);
      };

      static IAddExtraStepsToAStartupPipeline result;
      static IRun combined_step;
      static IRun the_action;
    }

    public class when_specifying_the_only_step_to_run : concern_for_initial_step
    {
      Establish c = () =>
      {
        the_step = fake.an<IRunAStartupStep>();

        depends.on<ICreateStartupStep>(x =>
        {
          x.ShouldEqual(typeof(FirstStep));
          return the_step;
        });
        depends.on<IList<IRunAStartupStep>>(new List<IRunAStartupStep>());
      };

      Because b = () =>
        sut.only_running<FirstStep>();

      It creates_and_runs_the_step = () =>
        the_step.should().have_received(x => x.run());

      static IRunAStartupStep the_step;
    }

    public class when_provided_an_initial_step : concern_for_initial_step
    {
      Establish c = () =>
      {
        the_step = fake.an<IRunAStartupStep>();
        combined_step = () =>
        {
          
        };

        depends.on<ICombineActions>((first, second) =>
        {
          first.ShouldBeAssignableTo<IRun>();
          second.ShouldEqual(the_step.run);
          return combined_step;
        });

        depends.on<ICreateStartupStep>(x =>
        {
          x.ShouldEqual(typeof(FirstStep));
          return the_step;
        });
        depends.on<IList<IRunAStartupStep>>(new List<IRunAStartupStep>());
      };

      Because b = () =>
        result = sut.running<FirstStep>();

      It returns_a_new_builder_with_the_first_step_created = () =>
        result.downcast_to<StartupPipelineBuilder>().step.ShouldEqual(combined_step);

      It allows_the_client_to_continue_adding_steps_to_the_pipeline = () =>
      {
        result.ShouldBeAssignableTo<IAddExtraStepsToAStartupPipeline>();
        result.Equals(sut).ShouldBeFalse();
      };

      static IRunAStartupStep the_step;
      static IAddExtraStepsToAStartupPipeline result;
      static IRun combined_step;
    }

    public class when_specifying_successive_steps : concern_for_adding_steps
    {
      Establish c = () =>
      {
        first_step = fake.an<IRunAStartupStep>();
        second_step = fake.an<IRunAStartupStep>();
        combined_step = () =>
        {

        };

        depends.on<ICombineActions>((first, second) =>
        {
          first.ShouldEqual(first_step.run);
          second.ShouldEqual(second_step.run);
          return combined_step;
        });

        depends.on<IRun>(first_step.run);
        depends.on<ICreateStartupStep>(x =>
        {
          x.ShouldEqual(typeof(SecondStep));
          return second_step;
        });
      };

      Because b = () =>
        result = sut.then<SecondStep>();

      It stores_the_step_created_by_the_step_factory_in_a_list_of_all_steps_to_run = () =>
        result.downcast_to<StartupPipelineBuilder>().step.ShouldEqual(combined_step);

      It returns_a_builder_to_continue_adding_steps = () =>
        result.ShouldNotEqual(sut);

      static IRunAStartupStep first_step;
      static IAddExtraStepsToAStartupPipeline result;
      static IRunAStartupStep second_step;
      static IRun combined_step;
    }

    public class when_the_last_step_is_specified : concern_for_adding_steps
    {
      Establish c = () =>
      {
        first_step = depends.on<IRun>();
        second_step = fake.an<IRunAStartupStep>();
        combined_step = () =>
        {
          ran = true;
        };

        depends.on<ICombineActions>((first,second) =>
        {
          first.ShouldEqual(first_step);
          second.ShouldEqual(second_step.run);
          return combined_step;
        });

        depends.on<ICreateStartupStep>(x =>
        {
          x.ShouldEqual(typeof(SecondStep));
          return second_step;
        });
      };

      Because b = () =>
        sut.finish_with<SecondStep>();

      It runs_all_of_the_steps_in_sequence = () =>
        ran.ShouldBeTrue();

      static IRun first_step;
      static IRunAStartupStep second_step;
      static IRun combined_step;
      static bool ran;
    }
  }

  public class SecondStep : IRunAStartupStep
  {
    public void run()
    {
    }
  }

  public abstract class concern_for_adding_steps : spec.observe<IAddExtraStepsToAStartupPipeline,
    StartupPipelineBuilder>
  {
  }

  public class FirstStep : IRunAStartupStep
  {
    public void run()
    {
      throw new NotImplementedException();
    }
  }
}
