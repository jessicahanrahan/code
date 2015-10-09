using Machine.Specifications;
using spec =
  developwithpassion.specifications.observations.Spec.isolate_with<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

namespace code.matching.extended
{
  [Subject(typeof(MatchingExtensionPoint<>))]
  public class ObjectMatchExtensionsSpecs
  {
    public abstract class concern<Target> : spec.observe<MatchingExtensionPoint<Target>>
    {
    }

    public class when_matching 
    {
      public class nulls : concern<object>
      {
        Establish c = () =>
        {
          sut_factory.create_using(() => Matches.a<object>().is_null());
        };

        It matches_correctly = () =>
        {
          sut.matches(null).ShouldBeTrue();
          sut.matches(1).ShouldBeFalse();
        };
      }

      public class equality : concern<int>
      {
        Establish c = () =>
        {
          sut_factory.create_using(() => Matches.a<int>().equal_to(10));
        };

        It matches_correctly = () =>
        {
          sut.matches(10).ShouldBeTrue();
          sut.matches(11).ShouldBeFalse();
        };
      }
    }
  }
}