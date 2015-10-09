using Machine.Specifications;
using spec =
  developwithpassion.specifications.observations.Spec.isolate_with<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

namespace code.matching.extended
{
  [Subject(typeof(StringMatchingExtensions))]
  public class StringMatchingExtensionsSpecs
  {
    public abstract class concern : spec.observe<MatchingExtensionPoint<string>>
    {
    }

    public class creating_matchers : concern
    {
      public class matching_an_empty_string
      {
        Establish c = () =>
        {
          sut_factory.create_using(() => Matches.a<string>().is_empty());
        };

        It matches_an_emtpy_string = () =>
          sut.matches("").ShouldBeTrue();

        It does_not_match_whitespace = () =>
          sut.matches("    ").ShouldBeFalse();

        It does_not_match_null = () =>
          sut.matches(null).ShouldBeFalse();
      }

      public class matching_null
      {
        Establish c = () =>
        {
          sut_factory.create_using(() => Matches.a<string>().is_null());
        };

        It matches_null = () =>
          sut.matches(null).ShouldBeTrue();

        It does_not_match_whitespace = () =>
          sut.matches("    ").ShouldBeFalse();

        It does_not_match_empty = () =>
        {
          sut.matches("").ShouldBeFalse();
          sut.matches(string.Empty).ShouldBeFalse();
        };
      }

      public class matching_ssn
      {
        Establish c = () =>
        {
          sut_factory.create_using(() => Matches.a<string>().social_security_number());
        };

        It matches_a_valid_ssn = () =>
          sut.matches("222-22-3433").ShouldBeTrue();

        It matches_a_valid_ssn_without_the_dashes = () =>
          sut.matches("222223433").ShouldBeTrue();

        It does_not_match_an_invalid_ssn = () =>
          sut.matches("222-2-3433").ShouldBeFalse();

        It does_not_match_an_invalid_ssn_without_the_dashes = () =>
          sut.matches("22223433").ShouldBeFalse();
      }

	  public class matching_email
	  {
		Establish c = () =>
		{
		  sut_factory.create_using(() => Matches.a<string>().email_address());
		};

		It matches_a_valid_email = () =>
		  sut.matches("b@gmail.com").ShouldBeTrue();

		It matches_a_valid_email_without_the_dot = () =>
		  sut.matches("b@gmail").ShouldBeTrue();

		It does_not_match_an_invalid_email = () =>
		  sut.matches("b.g").ShouldBeFalse();

		It does_not_match_an_invalid_email_without_the_at = () =>
		  sut.matches("bgmail.com").ShouldBeFalse();
	  }
    }
  }
}