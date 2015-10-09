using System.Web;
using System.Web.Compilation;
using code.stubs;
using code.web.aspnet.stubs;
using code.web.core;

namespace code.web.aspnet
{
  public class Registry : StructureMap.Configuration.DSL.Registry
  {
    public Registry()
    {
      ForSingletonOf<IHttpHandler>().Use<AspNetRawRequestHandler>();
      ForSingletonOf<IDisplayInformation>().Use<WebFormsDisplayEngine>();
      ForSingletonOf<ICreateAspxTemplateInstances>().Use<TemplateBuilder>();
      ForSingletonOf<IGetPathsToAspxTemplates>().Use<StubTemplatePaths>();
      ForSingletonOf<ICreatePageInstances>().Use<ICreatePageInstances>((path,type) => (IHttpHandler)BuildManager.CreateInstanceFromVirtualPath(path, type));
      ForSingletonOf<ICreateAControllerRequestFromAnAspNetRequest>().Use(Startup.controller_request_builder);
      ForSingletonOf<ICreateAHandlerWhenNoneExistForARequest>().Use(Startup.missing_handler_builder);
    }
  }
}