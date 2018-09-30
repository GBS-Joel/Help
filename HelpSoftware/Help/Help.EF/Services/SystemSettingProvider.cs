using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.EF
{
  public class SystemSettingProvider : HelpBaseService<SystemSettingProvider>
  {
    public SystemSettingProvider()
    {

    }

    public override List<SystemSettingProvider> GetAllEntities()
    {
      throw new NotImplementedException();
    }

    public override SystemSettingProvider GetEntityByID(int id)
    {
      throw new NotImplementedException();
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