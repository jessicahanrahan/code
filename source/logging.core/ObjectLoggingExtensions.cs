using System.Text;
using developwithpassion.specifications.extensions;

namespace code.logging.core
{
  public class ObjectLoggingExtensionPoint
  {
    ILogMessages logger;

    public ObjectLoggingExtensionPoint(ILogMessages logger)
    {
      this.logger = logger;
    }

    public void dump_object_properties(object instance)
    {
      var builder = new StringBuilder();
      var type = instance.GetType();

      builder.AppendFormat("Property Values for: {0}\r\n", type.Name);

      type.GetProperties().for_iteration().each(x =>
      {
        builder.AppendFormat("\t\r\n\t[{0}] -> {1}", x.Name, x.GetValue(instance));
      });

      logger.info(builder.ToString());
    }
  }
  public static class ObjectLoggingExtensionGateway
  {
    public static ObjectLoggingExtensionPoint object_details(this ILogMessages logger)
    {
      return new ObjectLoggingExtensionPoint(logger);
    }
  }
}
