namespace code.web.core
{
  public interface IHandleAllTheWebRequests
  {
    void process(IProvideDetailsToHandlers web_request);
  }
}