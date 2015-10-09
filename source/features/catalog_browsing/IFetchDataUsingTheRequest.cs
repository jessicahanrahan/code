using code.web.core;

namespace code.features.catalog_browsing
{
  public delegate Data IFetchDataUsingTheRequest<Data>(IProvideDetailsToHandlers request);

  public interface IFetchDataUsingARequest<Data>
  {
    Data fetch_using(IProvideDetailsToHandlers request);
  }
}