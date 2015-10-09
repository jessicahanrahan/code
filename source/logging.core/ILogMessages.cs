namespace code.logging.core
{
  public interface ILogMessages
  {
    void debug(string format, params object[] args);
    void info(string format, params object[] args);
    void error(string format, params object[] args);
  }
}