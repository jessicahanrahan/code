using System.Web;

namespace code.web.core
{
  public delegate IProvideDetailsToHandlers 
    ICreateAControllerRequestFromAnAspNetRequest(HttpContext request);

}