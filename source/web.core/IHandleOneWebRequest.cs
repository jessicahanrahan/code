namespace code.web.core
{
  public interface IHandleOneWebRequest : IRunAUserFeature
  {
    bool can_process(IProvideDetailsToHandlers request);
  }
}