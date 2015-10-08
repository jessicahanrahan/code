using System;
using System.Collections.Generic;

namespace code.web
{
  public class WebHandlers : IGetWebRequestHandlers
  {
      IEnumerable<IHandleOneWebRequest> all_handlers;

      public WebHandlers(IEnumerable<IHandleOneWebRequest> all_handlers)
      {
          this.all_handlers = all_handlers;
      }

      public IHandleOneWebRequest get_handler_for_request(IProvideDetailsToHandlers request)
    {
        foreach (var handler in all_handlers)
        {
            if (handler.can_process(request))
            {
                return handler;
            }
        }

        throw new NotImplementedException("Either at least one handler needs to be matched or null case needs to be handled");
    }
  }
}