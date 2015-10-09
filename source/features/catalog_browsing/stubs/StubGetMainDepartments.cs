using System.Collections.Generic;
using System.Linq;
using code.web.core;

namespace code.features.catalog_browsing.stubs
{
  public class StubGetMainDepartments : IFetchDataUsingARequest<IEnumerable<Department>>
  {
    public IEnumerable<Department> fetch_using(IProvideDetailsToHandlers request)
    {
      return Enumerable.Range(1, 100).Select(x => new Department
      {
        name = x.ToString("Main Department 0")
      });
    }
  }

  public class StubDepartmentsInDepartments : IFetchDataUsingARequest<IEnumerable<Department>>
  {
    public IEnumerable<Department> fetch_using(IProvideDetailsToHandlers request)
    {
      return Enumerable.Range(1, 100).Select(x => new Department
      {
        name = x.ToString("Sub Department 0")
      });
    }
  }

  public class StubProductsInDepartments : IFetchDataUsingARequest<IEnumerable<Product>>
  {
    public IEnumerable<Product> fetch_using(IProvideDetailsToHandlers request)
    {
      return Enumerable.Range(1, 100).Select(x => new Product
      {
        name = x.ToString("Product 0")
      });
    }
  }
}