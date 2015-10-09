using code.web.core;

namespace code.web.aspnet
{
  public class WebFormsDisplayEngine : IDisplayInformation
  {
    ICreateAspxTemplateInstances template_builder;
    IGetTheCurrentRequestContext get_the_current_context;

    public WebFormsDisplayEngine(ICreateAspxTemplateInstances template_builder,
      IGetTheCurrentRequestContext get_the_current_context)
    {
      this.template_builder = template_builder;
      this.get_the_current_context = get_the_current_context;
    }

    public void display<ReportModel>(ReportModel report)
    {
      var template = template_builder.create_template_for(report);
      template.ProcessRequest(get_the_current_context());
    }
  }
}