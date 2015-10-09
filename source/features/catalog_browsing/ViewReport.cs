using code.containers;
using code.web.core;

namespace code.features.catalog_browsing
{
  public class ViewReport<Report> : IRunAUserFeature
  {
    IFetchDataUsingTheRequest<Report> query;
    IDisplayInformation display_engine;

    public ViewReport(IFetchDataUsingTheRequest<Report> query):this(query,
      Dependencies.fetch.an<IDisplayInformation>())
    {
    }

    public ViewReport(IFetchDataUsingARequest<Report> query):this(query.fetch_using)
    {
    }

    public ViewReport(IFetchDataUsingTheRequest<Report> query, IDisplayInformation display_engine)
    {
      this.query = query;
      this.display_engine = display_engine;
    }

    public void process(IProvideDetailsToHandlers request)
    {
      var result = query(request);
      display_engine.display(result);
    }
  }
}