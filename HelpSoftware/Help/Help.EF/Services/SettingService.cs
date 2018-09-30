using System.Collections.Generic;
using System.Linq;

namespace Help.EF
{
  public class SettingService : HelpBaseService<Setting>
  {
    public override List<Setting> GetAllEntities()
    {
      var qry = from s in HelpContext.Instance.Settings
                select s;
      return qry.ToList();
    }

    public override Setting GetEntityByID(int id)
    {
      var qry = from s in HelpContext.Instance.Settings
                where s.ID_UserSetting == id
                select s;
      return qry.FirstOrDefault();
    }
  }
}