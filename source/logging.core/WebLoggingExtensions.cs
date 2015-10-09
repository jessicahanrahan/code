using System.Collections.Specialized;
using System.Text;
using System.Web;
using developwithpassion.specifications.extensions;

namespace code.logging.core
{
  public class WebLoggingExtensionPoint
  {
    ILogMessages logger;

    public WebLoggingExtensionPoint(ILogMessages logger)
    {
      this.logger = logger;
    }

    public void dump_request_details(HttpContext context)
    {
      var builder = new StringBuilder();

      builder.AppendFormat("Params for: {0}\r\n", context.Request.Url);
      builder.AppendFormat("\tForm Details:\r\n");
      builder.AppendFormat("\t\r\n\t{0}", dump_collection("Form", context.Request.Form));
      builder.AppendFormat("\t\r\n\t{0}", dump_collection("Params", context.Request.Params));

      logger.info(builder.ToString());
    }

    string dump_collection(string name, NameValueCollection name_value_collection)
    {
      var builder = new StringBuilder();

      builder.AppendFormat("Details For Collection: {0}", name);
      name_value_collection.AllKeys.for_iteration().each(x =>
      {
        builder.AppendFormat("\tKey: [{0}] = {1}\r\n", x, name_value_collection[x]);
      });
      return builder.ToString();
    }
  }

  public static class WebLoggingExtensionGateway
  {
    public static WebLoggingExtensionPoint web_details(this ILogMessages logger)
    {
      return new WebLoggingExtensionPoint(logger);
    }
  }
}