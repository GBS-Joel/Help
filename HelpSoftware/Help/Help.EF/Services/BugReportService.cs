using System.Linq;
using System.Collections.Generic;

namespace Help.EF
{
  public class BugReportService : HelpBaseService<BugReport>
  {
    public override List<BugReport> GetAllEntities()
    {
      var qry = from r in HelpContext.Instance.BugReports
                select r;
      return qry.ToList();
    }

    public override BugReport GetEntityByID(int id)
    {
      var qry = from r in HelpContext.Instance.BugReports
                where r.ID_BugReport == id
                select r;
      return qry.First();
    }
  }
}