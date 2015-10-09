using System;
using System.IO;
using System.Xml;
using code.test_utilities;
using developwithpassion.specifications.observations;
using log4net;
using Machine.Fakes.Adapters.Rhinomocks;
using Machine.Specifications;

namespace code.logging.log4net
{
  [Subject(typeof(Registry))]
  public class RegistrySpecs
  {
    [Tags(TestTags.slow)]
    public class concern : Spec.isolate_with<RhinoFakeEngine>.observe<StructureMap.Configuration.DSL.Registry, Registry>
    {
    }

    class ConfigSections
    {
      public static string template = @"
<log4net>
  <appender name='RollingFileAppender' type='log4net.Appender.RollingFileAppender'>
    <file value='{0}' />
    <appendToFile value='true' />
    <rollingStyle value='Size' />
    <maxSizeRollBackups value='10' />
    <maximumFileSize value='100000KB' />
    <staticLogFileName value='true' />
    <layout type='log4net.Layout.PatternLayout'>
      <conversionPattern value='%d [%t] %-5p %c - %m%n' />
    </layout>
  </appender>

  <root>
    <level value='DEBUG' />
    <appender-ref ref='RollingFileAppender' />			
  </root>
</log4net>
";

      public static string config_section_for(string file)
      {
        return string.Format(template, file);
      }
    }

    public class when_the_application_has_started_up : concern
    {
      Establish c = () =>
      {
        output_file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output.txt");
        File.Delete(output_file);
        var doc = new XmlDocument();
        doc.Load(new StringReader(ConfigSections.config_section_for(output_file)));

        Delegates.IGetLog4NetConfigElement get_element = () => doc.DocumentElement;
        spec.change(() => Registry.get_config_element).to(get_element);
      };

      Because b = () =>
      {
        LogManager.GetLogger("blah").Info("Hello");
        LogManager.Shutdown();
      };

      It should_be_able_to_log_messages_with_log_4_net = () =>
        File.Exists(output_file).ShouldBeTrue();

      Cleanup cu = () =>
        File.Delete(output_file);

      static string output_file;
    }
  }
}