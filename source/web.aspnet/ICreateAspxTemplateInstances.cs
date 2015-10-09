using System.Web;

namespace code.web.aspnet
{
  public interface ICreateAspxTemplateInstances
  {
    IHttpHandler create_template_for<Report>(Report report);
  }
}