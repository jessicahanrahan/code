using System.Web;
using code.test_utilities;
using code.web.core;
using developwithpassion.specifications.assertions;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.observations;
using developwithpassion.specifications.should;
using Machine.Fakes.Adapters.Rhinomocks;
using Machine.Specifications;

namespace code.web.aspnet
{
  [Subject(typeof(WebFormsDisplayEngine))]
  public class WebFormsDisplayEngineSpecs
  {
    public abstract class concern :
      Spec.isolate_with<RhinoFakeEngine>.observe<IDisplayInformation, WebFormsDisplayEngine>
    {
    }

    public class when_displaying_a_report : concern
    {
      Establish c = () =>
      {
        current_context = depends.on(Objects.web.create_http_context());
        template = fake.an<IHttpHandler>();
        template_factory = depends.on<ICreateAspxTemplateInstances>();
        depends.on<IGetTheCurrentRequestContext>(() => current_context);
        report = new SomeReport();

        template_factory.setup(x => x.create_template_for(report)).Return(template);
      };

      Because b = () =>
        sut.display(report);

      It tells_the_template_for_the_report_to_process_using_the_active_http_context = () =>
        template.should().have_received(x => x.ProcessRequest(current_context));

      static ICreateAspxTemplateInstances template_factory;
      static IHttpHandler template;
      static HttpContext current_context;
      static SomeReport report;
    }

    public class SomeReport
    {
    }
  }
}