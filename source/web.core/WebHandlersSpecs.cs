using System.Collections.Generic;
using System.Linq;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.observations;
using Machine.Fakes.Adapters.Rhinomocks;
using Machine.Specifications;

namespace code.web.core
{
  [Subject(typeof(WebHandlers))]
  public class WebHandlersSpecs
  {
    public abstract class concern : Spec.isolate_with<RhinoFakeEngine>.observe<IGetWebRequestHandlers, WebHandlers>
    {
    }

    public class when_getting_the_handler_for_a_request : concern
    {
      public class and_it_has_the_handler
      {
        Establish c = () =>
        {
          handler_that_can_handle_request = fake.an<IHandleOneWebRequest>();
          request = fake.an<IProvideDetailsToHandlers>();
          all_handlers = Enumerable.Range(1, 1000).Select(x => fake.an<IHandleOneWebRequest>()).ToList();

          all_handlers.Add(handler_that_can_handle_request);

          handler_iterator = depends.on<IIterateRequestHandlers>();
          handler_iterator.setup(x => x.GetEnumerator()).Return(all_handlers.GetEnumerator());

          handler_that_can_handle_request.setup(x => x.can_process(request)).Return(true);
        };

        Because b = () =>
          result = sut.get_handler_for_request(request);

        It returns_the_handler_that_can_process_the_request = () =>
          result.ShouldEqual(handler_that_can_handle_request);

        static IHandleOneWebRequest result;
        static IHandleOneWebRequest handler_that_can_handle_request;
        static IProvideDetailsToHandlers request;
        static IList<IHandleOneWebRequest> all_handlers;
        static IIterateRequestHandlers handler_iterator;
      }

      public class and_it_does_not_have_the_handler
      {
        Establish c = () =>
        {
          request = fake.an<IProvideDetailsToHandlers>();
          all_handlers = Enumerable.Range(1, 1000).Select(x => fake.an<IHandleOneWebRequest>()).ToList();
          handler_iterator = depends.on<IIterateRequestHandlers>();
          handler_iterator.setup(x => x.GetEnumerator()).Return(all_handlers.GetEnumerator());
          special_case = fake.an<IHandleOneWebRequest>();

          depends.on<ICreateAHandlerWhenNoneExistForARequest>(x =>
          {
            x.ShouldEqual(request);
            return special_case;
          });

          depends.on<IEnumerable<IHandleOneWebRequest>>(all_handlers);
        };

        Because b = () =>
          result = sut.get_handler_for_request(request);

        It returns_the_handler_created_by_the_special_case_builder = () =>
          result.ShouldEqual(special_case);

        static IHandleOneWebRequest result;
        static IProvideDetailsToHandlers request;
        static IList<IHandleOneWebRequest> all_handlers;
        static IHandleOneWebRequest special_case;
        static IIterateRequestHandlers handler_iterator;
      }
    }
  }
}