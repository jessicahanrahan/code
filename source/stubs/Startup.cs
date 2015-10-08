using System;
using code.web;

namespace code.stubs
{
  public class Startup
  {
    public static ICreateAControllerRequestFromAnAspNetRequest controller_request_builder = x =>
    {
      return new StubRequest();
    };

    public static ICreateAHandlerWhenNoneExistForARequest missing_hanlder_builder = delegate
    {
      throw new NotImplementedException("There is no handler that can handle this request");
    };

    class StubRequest : IProvideDetailsToHandlers
    {
    }
  }
}