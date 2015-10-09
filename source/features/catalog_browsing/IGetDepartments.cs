using System.Collections.Generic;

namespace code.features.catalog_browsing
{
  public interface IGetDepartments
  {
    IEnumerable<Department> departments_in(DepartmentsInDepartmentInput input);
    IEnumerable<Department> main_departments();
  }
}