using System.Web;

namespace code.web.stubs
{
  public class StubDisplayEngine : IDisplayInformation
  {
    public void display<ReportModel>(ReportModel report)
    {
      HttpContext.Current.Items.Add("report", report);
      HttpContext.Current.Server.Transfer("~/views/DepartmentBrowser.aspx");
    }
  }
}