using System;
using System.Web;
using System.Web.Compilation;
using code.web;
using code.web.aspnet;

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

    public static IGetTheCurrentRequestContext get_current_request =
      () => HttpContext.Current;

    public static ICreatePageInstances create_page_instance = (path, type) =>
      (IHttpHandler)BuildManager.CreateInstanceFromVirtualPath(path, type);

    class StubRequest : IProvideDetailsToHandlers
    {
    }
  }
}