using System.Collections;
using System.Collections.Generic;
using code.containers;
using code.features.catalog_browsing;

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
      yield return new RequestHandler(x => true, Dependencies.fetch.an<ViewMainDepartments>());
    }
  }
}