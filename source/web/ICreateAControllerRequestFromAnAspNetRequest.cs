using System.Web;

namespace code.web
{
  public delegate IProvideDetailsToHandlers 
    ICreateAControllerRequestFromAnAspNetRequest(HttpContext request);

}