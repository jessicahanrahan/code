using System;
using System.Diagnostics;

namespace code.logging.core
{
  public class Log
  {
    class SimpleLogger : ILogMessages
    {
      public void info(string format, params object[] args)
      {
        Console.Out.WriteLine("[INFO]:" + format, args);
      }

      public void error(string format, params object[] args)
      {
        Console.Out.WriteLine("[ERROR]:" + format, args);
      }

      public void debug(string format, params object[] args)
      {
        Console.Out.WriteLine("[DEBUG]:" + format, args);
      }
    }

    public static IGetTheCallingType get_calling_type = delegate
    {
      return new StackFrame(2).GetMethod().DeclaringType;
    };

    public static ILogMessages an
    {
      get { return log_factory(get_calling_type()); }
    }

    public static ICreateALoggerBoundToAType log_factory = delegate {
      return new SimpleLogger();
    };
  }
}