using System.Web;
using code.test_utilities;
using code.web.aspnet;
using developwithpassion.specifications.assertions;
using developwithpassion.specifications.observations;
using developwithpassion.specifications.should;
using Machine.Fakes.Adapters.Rhinomocks;
using Machine.Specifications;

namespace code.web.core
{
  [Subject(typeof(AspNetRawRequestHandler))]
  public class AspNetRawRequestHandlerSpecs
  {
    public abstract class concern : Spec.isolate_with<RhinoFakeEngine>.observe<IHttpHandler, AspNetRawRequestHandler>
    {
    }

    public class when_processing_a_new_http_context : concern
    {
      Establish c = () =>
      {
        a_new_controller_request = fake.an<IProvideDetailsToHandlers>();
        a_aspnet_request = Objects.web.create_http_context();

        depends.on<ICreateAControllerRequestFromAnAspNetRequest>(x =>
        {
          x.ShouldEqual(a_aspnet_request);
          return a_new_controller_request;
        });

        front_controller = depends.on<IHandleAllTheWebRequests>();
      };

      Because b = () =>
        sut.ProcessRequest(a_aspnet_request);

      It delegates_the_processing_of_a_new_front_controller_request_to_our_front_controller = () =>
        front_controller.should().have_received(x => x.process(a_new_controller_request));

      static IHandleAllTheWebRequests front_controller;
      static IProvideDetailsToHandlers a_new_controller_request;
      static HttpContext a_aspnet_request;
    }
  }
}