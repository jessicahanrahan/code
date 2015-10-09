using System.Linq;

namespace code.web.core
{
  public class WebHandlers : IGetWebRequestHandlers
  {
    IIterateRequestHandlers all_the_handlers;
    ICreateAHandlerWhenNoneExistForARequest create_the_missing_handler;

    public WebHandlers(IIterateRequestHandlers all_the_handlers,
      ICreateAHandlerWhenNoneExistForARequest special_case)
    {
      this.all_the_handlers = all_the_handlers;
      create_the_missing_handler = special_case;
    }

    public IHandleOneWebRequest get_handler_for_request(IProvideDetailsToHandlers request)
    {
      return all_the_handlers.FirstOrDefault(x => x.can_process(request)) ??
             create_the_missing_handler(request);
    }
  }
}