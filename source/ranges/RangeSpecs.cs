using developwithpassion.specifications.assertions;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.observations;
using developwithpassion.specifications.should;
using Machine.Fakes.Adapters.Rhinomocks;
using Machine.Specifications;

namespace code.ranges
{
    [Subject(typeof(Range))]
    public class RangeSpecs
    {
        public abstract class range_concern : Spec.isolate_with<RhinoFakeEngine>.observe<IHandleAllTypesOfRanges,
          Range>
        {
        }

        public class when_comparing_two_values : range_concern
        {
            //Establish c = () =>
            //{
               
            //};

            //Because b = () =>
              

            //It  = () =>
            //  handler_that_can_handle_request.should().have_received(x => x.process(web_request));

            //static IProvideDetailsToHandlers web_request;
            //static IGetWebRequestHandlers web_handlers;
            //static IHandleOneWebRequest handler_that_can_handle_request;
        }
    }
}
