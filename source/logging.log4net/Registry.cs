using code.logging.core;
using log4net;
using log4net.Config;

namespace code.logging.log4net
{
  public class Registry : StructureMap.Configuration.DSL.Registry
  {
    public static Delegates.IGetLog4NetConfigElement get_config_element =
      Delegates.get_log_4_net_config_element;

    void load_configuration()
    {
      XmlConfigurator.Configure(get_config_element());
    }

    public Registry()
    {
      load_configuration();

      Log.log_factory = type =>
        new Log4NetLogger(LogManager.GetLogger(type));
    }
  }
}