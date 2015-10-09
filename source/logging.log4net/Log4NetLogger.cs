using code.logging.core;
using log4net;

namespace code.logging.log4net
{
	public class Log4NetLogger : ILogMessages
	{
		ILog log;

		public Log4NetLogger(ILog log)
		{
			this.log = log;
		}

		public void info(string format, params object[] args)
		{
			log.InfoFormat(format, args);
		}

		public void error(string format, params object[] args)
		{
			log.ErrorFormat(format, args);
		}

	  public void debug(string format, params object[] args)
	  {
	    log.DebugFormat(format, args);
	  }
	}
}