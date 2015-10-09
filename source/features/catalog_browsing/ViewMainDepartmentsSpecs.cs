using System.Collections.Generic;
using code.web;
using code.web.core;
using developwithpassion.specifications.assertions;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.observations;
using developwithpassion.specifications.should;
using Machine.Fakes.Adapters.Rhinomocks;
using Machine.Specifications;

namespace code.features.catalog_browsing
{  
  [Subject(typeof(ViewMainDepartments))]  
  public class ViewMainDepartmentsSpecs
  {

    public abstract class concern : Spec.isolate_with<RhinoFakeEngine>.observe<IRunAUserFeature,ViewMainDepartments>
    {
        
    }

   
    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideDetailsToHandlers>();
        display_engine = depends.on<IDisplayInformation>();
        departments = depends.on<IGetDepartments>();

        main_departments = new List<Department>
        {
          new Department()
        };

        departments.setup(x => x.main_departments()).Return(main_departments);
      };

      Because b = () =>
        sut.process(request);

      It gets_the_main_departments = () =>
        departments.should().have_received(x => x.main_departments());

      It displays_the_main_departments = () =>
        display_engine.should().have_received(x => x.display(main_departments));

      static IGetDepartments departments;
      static IProvideDetailsToHandlers request;
      static IDisplayInformation display_engine;
      static IEnumerable<Department> main_departments;
    }
  }
}
