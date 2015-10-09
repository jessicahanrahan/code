using Machine.Specifications;
using spec =
  developwithpassion.specifications.observations.Spec.isolate_with<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

namespace code.matching.extended
{
  [Subject(typeof(ComparableMatchExtensions))]
  public class ComparableMatchExtensionsSpecs
  {
    public abstract class concern<Target> : spec.observe<MatchingExtensionPoint<Target>>
    {

    }

    public class matching_comparable_types : concern<int>
    {
      public class less_than_comparisons
      {
        Establish c = () =>
        {
          sut_factory.create_using(() => Matches.a<int>().less_than(10)); 
        };


        It matches_correctly = () =>
        {
          sut.matches(9).ShouldBeTrue();
          sut.matches(10).ShouldBeFalse();
          sut.matches(11).ShouldBeFalse();
        };
          
      }
        
      public class greater_than_comparisons
      {
        Establish c = () =>
        {
          sut_factory.create_using(() => Matches.a<int>().greater_than(10)); 
        };


        It matches_correctly = () =>
        {
          sut.matches(10).ShouldBeFalse();
          sut.matches(11).ShouldBeTrue();
        };
          
      }

      public class greater_than_or_equal_comparisons
      {
        Establish c = () =>
        {
          sut_factory.create_using(() => Matches.a<int>().greater_than_or_equal_to(10)); 
        };


        It matches_correctly = () =>
        {
          sut.matches(9).ShouldBeFalse();
          sut.matches(10).ShouldBeTrue();
          sut.matches(11).ShouldBeTrue();
        };
          
      }

      public class less_than_or_equal_comparisons
      {
        Establish c = () =>
        {
          sut_factory.create_using(() => Matches.a<int>().less_than_or_equal_to(10)); 
        };


        It matches_correctly = () =>
        {
          sut.matches(10).ShouldBeTrue();
          sut.matches(9).ShouldBeTrue();
          sut.matches(11).ShouldBeFalse();
        };
          
      }
    }
  }
}
