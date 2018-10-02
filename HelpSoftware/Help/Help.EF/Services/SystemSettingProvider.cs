using System.Collections.Generic;
using System.Linq;

namespace Help.EF
{
  public class SystemSettingProvider : HelpBaseService<SystemSetting>
  {
    public override List<SystemSetting> GetAllEntities()
    {
      var qry = from s in HelpContext.Instance.SystemSettings
                select s;
      return qry.ToList();
    }

    public override SystemSetting GetEntityByID(int id)
    {
      var qry = from s in HelpContext.Instance.SystemSettings
                where s.ID_SystemSetting == id
                select s;
      return qry.FirstOrDefault();
    }

    public SystemSetting GetSystemSettingByName(string Name)
    {
      var getsystemsettingbyName = from s in HelpContext.Instance.SystemSettings
                                   where s.Name == Name
                                   select s;
      return getsystemsettingbyName.FirstOrDefault();
    }
  }
}