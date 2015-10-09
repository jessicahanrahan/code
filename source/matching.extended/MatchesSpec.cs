using Machine.Specifications;
using spec =
  developwithpassion.specifications.observations.Spec.isolate_with<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

namespace code.matching.extended
{
  [Subject(typeof(Matches))]
  public class MatchesSpec
  {
    public abstract class concern : spec
    {
    }

    public class when_building_a_matcher : concern
    {
      It creates_a_matcher_that_always_matches_the_target_type = () =>
      {
        Matches.a<int>().matches(42).ShouldBeTrue();
      };

      It can_create_a_composite_or_match_with_an_inline_constraint = () =>
      {
        var rule = Matches.a<int>().equal_to(10).or(x => x != 12);
        rule.matches(10).ShouldBeTrue();
        rule.matches(11).ShouldBeTrue();
        rule.matches(12).ShouldBeFalse();
      };

      It can_create_a_composite_or_match_with_an_extension_on_a_matcher = () =>
      {
        var rule = Matches.a<int>().equal_to(10).or(x => x.greater_than(12));
        rule.matches(10).ShouldBeTrue();
        rule.matches(13).ShouldBeTrue();
        rule.matches(11).ShouldBeFalse();
      };

      It can_create_a_composite_and_match_with_an_inline_constraint = () =>
      {
        var rule = Matches.a<int>().greater_than(10).and(x => x != 12);
        rule.matches(11).ShouldBeTrue();
        rule.matches(13).ShouldBeTrue();
        rule.matches(12).ShouldBeFalse();
      };

      It can_create_a_composite_and_match_with_an_extension_on_a_matcher = () =>
      {
        var rule = Matches.a<int>().greater_than(10).and(x => x.greater_than(12));
        rule.matches(11).ShouldBeFalse();
        rule.matches(12).ShouldBeFalse();
        rule.matches(13).ShouldBeTrue();
      };

    }
  }
}