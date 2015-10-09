using System;
using System.IO;
using System.Xml;

namespace code.logging.log4net
{
  public class Delegates
  {
    public delegate XmlElement IGetLog4NetConfigElement();

    public static readonly IGetLog4NetConfigElement get_log_4_net_config_element = () =>
    {
      var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config.xml");
      var doc = new XmlDocument();
      doc.Load(File.OpenRead(path));
      return doc.DocumentElement;
    };
  }
}