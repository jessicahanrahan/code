using System.Collections.Generic;
using code.web.core;
using developwithpassion.specifications.assertions;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.observations;
using developwithpassion.specifications.should;
using Machine.Fakes.Adapters.Rhinomocks;
using Machine.Specifications;

namespace code.features.catalog_browsing
{
  [Subject(typeof(ViewDepartmentsInADepartment))]
  public class ViewDepartmentsInADepartmentSpecs
  {
    public abstract class concern : Spec.isolate_with<RhinoFakeEngine>.observe<IRunAUserFeature, ViewMainDepartments>
    {
    }

    public class FakeRequest : IProvideDetailsToHandlers
    {
      object result;

      public FakeRequest(object result)
      {
        this.result = result;
      }

      public Input map<Input>()
      {
        return (Input) result;
      }
    }

    public class FakeDepartments : IGetDepartments
    {
      IEnumerable<Department> result;

      public FakeDepartments(IEnumerable<Department> result)
      {
        this.result = result;
      }

      public IEnumerable<Department> departments_in(DepartmentsInDepartmentInput input)
      {
        return result;
      }

      public IEnumerable<Department> main_departments()
      {
        throw new System.NotImplementedException();
      }
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        sub_departments = new List<Department>
        {
          new Department()
        };
        display_engine = depends.on<IDisplayInformation>();
        departments = new FakeDepartments(sub_departments);
        input = new DepartmentsInDepartmentInput();
        request = new FakeRequest(input);
      };

      Because b = () =>
        sut.process(request);

      It displays_the_sub_departments = () =>
        display_engine.should().have_received(x => x.display(sub_departments));

      static IGetDepartments departments;
      static IProvideDetailsToHandlers request;
      static IDisplayInformation display_engine;
      static IEnumerable<Department> sub_departments;
      static DepartmentsInDepartmentInput input;
    }
  }
}