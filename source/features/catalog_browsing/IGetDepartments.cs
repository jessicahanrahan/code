using System.Collections.Generic;

namespace code.features.catalog_browsing
{
  public interface IGetDepartments
  {
    IEnumerable<Department> main_departments();
  }
}