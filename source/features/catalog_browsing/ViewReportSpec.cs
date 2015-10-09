using code.web.core;
using developwithpassion.specifications.assertions;
using developwithpassion.specifications.observations;
using developwithpassion.specifications.should;
using Machine.Fakes.Adapters.Rhinomocks;
using Machine.Specifications;

namespace code.features.catalog_browsing
{
  [Subject(typeof(ViewReport<>))]
  public class ViewAReportSpecs
  {
    public abstract class concern : Spec.isolate_with<RhinoFakeEngine>.observe<IRunAUserFeature, ViewReport<SomeReport>>
    {
    }


    public class when_run : concern
    {
      Establish c = () =>
      {
        report = new SomeReport();
        request = fake.an<IProvideDetailsToHandlers>();
        display_engine = depends.on<IDisplayInformation>();

        depends.on<IFetchDataUsingTheRequest<SomeReport>>(x =>
        {
          x.ShouldEqual(request);
          return report;
        });
      };

      Because b = () =>
        sut.process(request);

      It displays_the_result_of_running_its_query = () =>
        display_engine.should().have_received(x => x.display(report));

      static IDisplayInformation display_engine;
      static SomeReport report;
      static IProvideDetailsToHandlers request;
    }

    public class SomeReport
    {
    }
  }
}