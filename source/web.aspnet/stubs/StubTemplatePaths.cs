using System;
using System.Collections.Generic;
using code.features.catalog_browsing;

namespace code.web.aspnet.stubs
{
  public class StubTemplatePaths : IGetPathsToAspxTemplates
  {
    public string get_path_to_template_for<Report>()
    {
      var paths = new Dictionary<Type, string>
      {
        {typeof(IEnumerable<MainDepartment>), "~/views/DepartmentBrowser.aspx"}
      }; 

      if (paths.ContainsKey(typeof(Report))) return paths[typeof(Report)];

      throw new NotImplementedException("There is no template for the report");
    }
  }
}