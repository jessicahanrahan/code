using System.Web;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.observations;
using Machine.Fakes.Adapters.Rhinomocks;
using Machine.Specifications;

namespace code.web.aspnet
{
  [Subject(typeof(TemplateBuilder))]
  public class TemplateBuilderSpecs
  {
    public abstract class concern :
      Spec.isolate_with<RhinoFakeEngine>.observe<ICreateAspxTemplateInstances, TemplateBuilder>
    {
    }

    public class when_creating_a_template_instance_for_a_report : concern
    {
      Establish c = () =>
      {
        report = new MyReport();
        template_paths = depends.on<IGetPathsToAspxTemplates>();
        path_to_template = "blah.aspx";
        template_instance = fake.an<IDisplayA<MyReport>>();

        depends.on<ICreatePageInstances>((path, type) =>
        {
          path.ShouldEqual(path_to_template);
          type.ShouldEqual(typeof(IDisplayA<MyReport>));

          return template_instance;
        });

        template_paths.setup(x => x.get_path_to_template_for<MyReport>())
          .Return(path_to_template);
      };

      Because b = () =>
        result = sut.create_template_for(report);

      It provides_the_template_with_its_data = () =>
        template_instance.report.ShouldEqual(report);

      It returns_the_template_instance = () =>
        result.ShouldEqual(template_instance);

      static IGetPathsToAspxTemplates template_paths;
      static MyReport report;
      static string path_to_template;
      static IHttpHandler result;
      static IDisplayA<MyReport> template_instance;
    }

    public class MyReport
    {
    }
  }
}