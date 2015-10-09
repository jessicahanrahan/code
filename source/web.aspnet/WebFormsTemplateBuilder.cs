using System.Web;
using code.core;
using code.stubs;
using code.web.aspnet.stubs;

namespace code.web.aspnet
{
  public class WebFormsTemplateBuilder : ICreateAspxTemplateInstances
  {
    IGetPathsToAspxTemplates template_paths;
    ICreatePageInstances template_builder;

    public WebFormsTemplateBuilder():this(new StubTemplatePaths(), 
      Startup.create_page_instance)
    {
    }

    public WebFormsTemplateBuilder(IGetPathsToAspxTemplates template_paths, ICreatePageInstances template_builder)
    {
      this.template_paths = template_paths;
      this.template_builder = template_builder;
    }


    public IHttpHandler create_template_for<Report>(Report report)
    {
      var path = template_paths.get_path_to_template_for<Report>();
      var template_instance = template_builder(path, typeof(IDisplayA<Report>)).cast_to<IDisplayA<Report>>();

      template_instance.report = report;

      return template_instance;
    }
  }
}