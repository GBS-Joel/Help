using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.EF
{
  public class SystemSettingService : HelpBaseService<SystemSetting>
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
      var qry = from s in HelpContext.Instance.SystemSettings
                where s.Name == Name
                select s;
      return qry.FirstOrDefault();
    }
  }
}