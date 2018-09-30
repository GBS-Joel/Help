using System.Collections.Generic;
using System.Linq;

namespace Help.EF
{
  public class ActivityService : HelpBaseService<Activity>
  {
    public override List<Activity> GetAllEntities()
    {
      EFLogger.EFLog("Get All Entities on ActivityService");
      var qry = from a in HelpContext.Instance.Activities
                select a;
      EFLogger.EFLog("Found " + qry.ToList().Count + " Entities on ActivityService");
      return qry.ToList();
    }

    public override Activity GetEntityByID(int id)
    {
      EFLogger.EFLog("Get Activity with ID " + id);
      var qry = from a in HelpContext.Instance.Activities
                where a.ID_Activity == id
                select a;
      Activity act = qry.FirstOrDefault();
      if (act != null)
      {
        EFLogger.EFLog("Found Activity with ID " + id);
        return act;
      }
      else
      {
        EFLogger.EFLog("Could Not Found Activity with ID " + id);
        return null;
      }
    }
  }
}