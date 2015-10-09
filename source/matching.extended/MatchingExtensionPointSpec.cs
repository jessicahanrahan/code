using System;
using code.core;
using code.startup.core;
using Machine.Specifications;
using spec =
  developwithpassion.specifications.observations.Spec.isolate_with<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

namespace code.matching.extended
{
  [Subject(typeof(MatchingExtensionPoint<>))]
  public class MatchingExtensionPointSpec
  {
    public abstract class concern<Target> : spec.observe<MatchingExtensionPoint<Target>>
    {
    }

    public class when_implictly_converting : concern<int>
    {
      Establish c = () =>
      {
        depends.on<ICheckAConstraint<int>>(x => true);
      };

      public class can_be_converted_to_a_func_bool_of_the_target_type
      {
        Because b = () =>
          result = sut;

        It can_be_converted_to_a_func = () =>
          result(1).ShouldBeTrue();

        static Func<int, bool> result;
      }

      public class can_be_converted_to_a_constraint_of_the_target_type
      {
        Because b = () =>
          result = sut;

        It can_be_converted_to_a_constraint = () =>
          result(1).ShouldBeTrue();

        static ICheckAConstraint<int> result;
      }
    }

    public class when_negating_a_condition : concern<int>
    {
      Establish c = () =>
      {
        depends.on<ICheckAConstraint<int>>(x => true);
      };

      Because b = () =>
        result = sut.not(x => MatchingExtensionPoint<int>.create_from(y => y == 2));

      It builds_a_condition_that_matches_the_negation = () =>
        result(2).ShouldBeFalse();

      static Func<int, bool> result;
    }
  }
}