using code.web;

namespace code.features.catalog_browsing
{
  public class ViewMainDepartments : IRunAUserFeature
  {
    IGetDepartments department_repo;

      public ViewMainDepartments(IGetDepartments department_repo)
      {
          this.department_repo = department_repo;
      }

      public void process(IProvideDetailsToHandlers request)
    {
        department_repo.main_departments();
    }
  }
}