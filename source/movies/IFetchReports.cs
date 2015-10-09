using code.core;

namespace code.movies
{
  public interface IFetchReports
  {
    Report run<Report>(IQueryForData<Report> query);
  }

  public class ReportGateway :IFetchReports
  {
    public Report run<Report>(IQueryForData<Report> query)
    {
      return query.run();
    }
  }
}