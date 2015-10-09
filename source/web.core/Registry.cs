using code.stubs;
using code.web.aspnet;
using code.web.core.stubs;

namespace code.web.core
{
  public class Registry : StructureMap.Configuration.DSL.Registry
  {
    public Registry()
    {
      ForSingletonOf<IHandleAllTheWebRequests>().Use<WebRequestHandler>();
      ForSingletonOf<IGetWebRequestHandlers>().Use<WebHandlers>();
      ForSingletonOf<IGetTheCurrentRequestContext>().Use(Startup.get_current_request);
      ForSingletonOf<IIterateRequestHandlers>().Use<StubSetOfHandlers>();
    }
  }
}