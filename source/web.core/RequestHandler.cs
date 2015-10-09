using code.enumerables;

namespace code.web.core
{
  public class RequestHandler : IHandleOneWebRequest
  {
    Criteria<IProvideDetailsToHandlers> request_criteria;
    IRunAUserFeature feature;

    public RequestHandler(Criteria<IProvideDetailsToHandlers> request_criteria, IRunAUserFeature feature)
    {
      this.request_criteria = request_criteria;
      this.feature = feature;
    }

    public void process(IProvideDetailsToHandlers web_request)
    {
      feature.process(web_request);
    }

    public bool can_process(IProvideDetailsToHandlers request)
    {
      return request_criteria(request);
    }
  }
}