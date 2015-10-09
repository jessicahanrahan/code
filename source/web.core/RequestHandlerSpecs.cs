using code.enumerables;
using developwithpassion.specifications.assertions;
using developwithpassion.specifications.observations;
using developwithpassion.specifications.should;
using Machine.Fakes.Adapters.Rhinomocks;
using Machine.Specifications;

namespace code.web.core
{  
  [Subject(typeof(RequestHandler))]  
  public class RequestHandlerSpecs
  {

    public abstract class concern : Spec.isolate_with<RhinoFakeEngine>.observe<IHandleOneWebRequest,RequestHandler>
    {
        
    }

   
    public class when_determining_if_it_can_process_a_request : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideDetailsToHandlers>();
        depends.on<Criteria<IProvideDetailsToHandlers>>(x => true);
      };

      Because b = () =>
        result = sut.can_process(request);

      It evaluates_the_result_of_its_request_specification = () =>
        result.ShouldBeTrue();

      static bool result;
      static IProvideDetailsToHandlers request;
    }

    public class when_processing_the_request : concern
    {
      Establish c = () =>
      {
        feature = depends.on<IRunAUserFeature>();
        request = fake.an<IProvideDetailsToHandlers>();
      };

      Because b = () =>
        sut.process(request);

      It run_the_application_feature_for_the_request = () =>
        feature.should().have_received(x => x.process(request));

      static IProvideDetailsToHandlers request;
      static IRunAUserFeature feature;
    }
  }
}
