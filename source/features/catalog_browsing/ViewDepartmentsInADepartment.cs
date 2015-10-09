using code.web.core;

namespace code.features.catalog_browsing
{
  public class ViewDepartmentsInADepartment : IRunAUserFeature
  {
    IGetDepartments departments;
    IDisplayInformation display_engine;

    public ViewDepartmentsInADepartment(IGetDepartments departments, 
      IDisplayInformation display_engine)
    {
      this.departments = departments;
      this.display_engine = display_engine;
    }

    public void process(IProvideDetailsToHandlers request)
    {
      var results = departments.departments_in(
        request.map<DepartmentsInDepartmentInput>());

      display_engine.display(results);
    }
  }
}