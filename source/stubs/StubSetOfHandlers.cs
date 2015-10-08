using System.Collections;
using System.Collections.Generic;
using code.features.catalog_browsing;
using code.web;

namespace code.stubs
{
  public class StubSetOfHandlers : IEnumerable<IHandleOneWebRequest>
  {
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<IHandleOneWebRequest> GetEnumerator()
    {
      yield return new RequestHandler(x => true, new ViewMainDepartments());
    }
  }
}