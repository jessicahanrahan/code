using System.Collections;
using System.Collections.Generic;
using code.containers;
using code.features.catalog_browsing;
using code.features.catalog_browsing.stubs;

namespace code.web.core.stubs
{
  public class StubSetOfHandlers : IIterateRequestHandlers
  {
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<IHandleOneWebRequest> GetEnumerator()
    {
      yield return create_report_for(new StubGetMainDepartments());

      yield return create_report_for(new StubDepartmentsInDepartments());

      yield return create_report_for(new StubProductsInDepartments());
    }

    IHandleOneWebRequest create_report_for<Item>(IFetchDataUsingARequest<Item> query)
    {
      return new RequestHandler(x => true, new ViewReport<Item>(query)); 
    }
  }
}