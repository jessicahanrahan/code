using code.web.core;

namespace code.features.catalog_browsing
{
  public class ViewMainDepartments : IRunAUserFeature
  {
    IGetDepartments departments;
    IDisplayInformation display_engine;

    public ViewMainDepartments(IGetDepartments departments, IDisplayInformation display_engine)
    {
      this.departments = departments;
      this.display_engine = display_engine;
    }

    public void process(IProvideDetailsToHandlers request)
    {
      var result = departments.main_departments();
      display_engine.display(result);
    }
  }
}