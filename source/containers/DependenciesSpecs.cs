using developwithpassion.specification.adapters.rhino_mocks;
using Machine.Specifications;

namespace code.containers
{
  [Subject(typeof(Dependencies))]
  public class DependenciesSpecs
  {
    public abstract class concern : spec
    {
    }

    public class when_providing_access_to_the_container_facade : concern
    {
      Establish c = () =>
      {
        the_container_facade = fake.an<IFetchDependencies>();
        IConfigureTheContainerFacade configuration = () => the_container_facade;

        spec.change(() => Dependencies.configure_the_container).to(configuration);
      };

      Because b = () =>
        result = Dependencies.fetch;

      It returns_the_facade_configured_during_the_startup_pipeline = () =>
        result.ShouldEqual(the_container_facade);

      static IFetchDependencies result;
      static IFetchDependencies the_container_facade;
    }
  }
}
