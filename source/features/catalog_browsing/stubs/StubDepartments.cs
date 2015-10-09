﻿using System.Collections.Generic;
using System.Linq;

namespace code.features.catalog_browsing.stubs
{
  public class StubDepartments : IGetDepartments
  {
    public IEnumerable<Department> main_departments()
    {
      return Enumerable.Range(1, 100).Select(x => new Department
      {
        name = x.ToString("Main Department 0")
      });
    }
  }
}