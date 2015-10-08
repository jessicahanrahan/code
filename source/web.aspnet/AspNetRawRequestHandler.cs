using System.Web;
using code.stubs;

namespace code.web.aspnet
{
  public class AspNetRawRequestHandler : IHttpHandler
  {
    IHandleAllTheWebRequests front_controller;
    ICreateAControllerRequestFromAnAspNetRequest request_builder;

    public AspNetRawRequestHandler():this(new WebRequestHandler(), 
      Startup.controller_request_builder)
    {
    }

    public AspNetRawRequestHandler(IHandleAllTheWebRequests front_controller, ICreateAControllerRequestFromAnAspNetRequest request_builder)
    {
      this.front_controller = front_controller;
      this.request_builder = request_builder;
    }

    public void ProcessRequest(HttpContext context)
    {
      var request = request_builder(context);
      front_controller.process(request);
    }

    public bool IsReusable
    {
      get { return true; }
    }
  }
}