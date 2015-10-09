using code.features.catalog_browsing.stubs;
using code.web;
using code.web.aspnet;

namespace code.features.catalog_browsing
{
  public class ViewMainDepartments : IRunAUserFeature
  {
    IGetDepartments departments;
    IDisplayInformation display_engine;

    public ViewMainDepartments() : this(new StubDepartments(),
      new WebFormsDisplayEngine())
    {
    }

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