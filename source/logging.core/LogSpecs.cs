using developwithpassion.specification.adapters.rhino_mocks;
using Machine.Specifications;

namespace code.logging.core
{
  public class Specs
  {
    public class concern : spec
    {

    }

    public class when_providing_access_to_the_logging_gateway: concern
    {
      Establish c = () =>
      {
        logger = fake.an<ILogMessages>();
        ICreateALoggerBoundToAType log_factory = (type) =>
        {
          type.ShouldEqual(typeof(when_providing_access_to_the_logging_gateway));
          return logger;
        };

        IGetTheCallingType calling_type = () => typeof(when_providing_access_to_the_logging_gateway);

        spec.change(() => Log.log_factory).to(log_factory);
        spec.change(() => Log.get_calling_type).to(calling_type);
      };

      Because b = () =>
        result = Log.an;

      It returns_a_logging_gateway_initialized_with_the_type_that_requested_logging = () =>
        result.ShouldEqual(logger);

      static ILogMessages logger;
      static ILogMessages result;
    }
  }
}
