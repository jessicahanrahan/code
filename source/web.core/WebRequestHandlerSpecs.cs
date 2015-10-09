using developwithpassion.specifications.assertions;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.observations;
using developwithpassion.specifications.should;
using Machine.Fakes.Adapters.Rhinomocks;
using Machine.Specifications;

namespace code.web.core
{
  [Subject(typeof(WebRequestHandler))]
  public class WebRequestHandlerSpecs
  {
    public abstract class concern : Spec.isolate_with<RhinoFakeEngine>.observe<IHandleAllTheWebRequests,
      WebRequestHandler>
    {
    }

    public class when_processing_a_web_request : concern
    {
      Establish c = () =>
      {
        web_handlers = depends.on<IGetWebRequestHandlers>();
        web_request = fake.an<IProvideDetailsToHandlers>();
        handler_that_can_handle_request = fake.an<IHandleOneWebRequest>();

        web_handlers.setup(x => x.get_handler_for_request(web_request)).Return(handler_that_can_handle_request);
      };

      Because b = () =>
        sut.process(web_request);

      It delegates_processing_of_the_request_to_the_handler_that_can_handle_it = () =>
        handler_that_can_handle_request.should().have_received(x => x.process(web_request));

      static IProvideDetailsToHandlers web_request;
      static IGetWebRequestHandlers web_handlers;
      static IHandleOneWebRequest handler_that_can_handle_request;
    }
  }
}