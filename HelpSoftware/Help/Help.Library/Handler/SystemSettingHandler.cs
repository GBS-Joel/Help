using Help.EF;
using System;
using System.Linq;

namespace Help.Library
{
  public class SystemSettingHandler
  {
    public void SyncDatabaseWithSystemSettings()
    {
      var a = Enum.GetValues(typeof(SystemSettings));
      foreach (var item in a)
      {
        CreateDefaultSystemSetting(item.ToString(), null);
      }
    }

    public void CreateDefaultSystemSetting(string Name, string DefaultVal)
    {
      if (!CheckIfSystemSettingsExist(Name))
      {
        CreateSystemSetting(Name, DefaultVal);
      }
    }

    public void CreateSystemSetting(string name, string DefaultVal)
    {
      SystemSetting s = new SystemSetting()
      {
        Created = DateTime.Now,
        Name = name,
        Value = DefaultVal
      };
      HelpContext.Instance.SystemSettings.Add(s);
      HelpContext.Instance.SaveChanges();
    }

    public bool CheckIfSystemSettingsExist(string Name)
    {
      var qry = from sys in HelpContext.Instance.SystemSettings
                where sys.Name == Name
                select sys;
      if (qry.FirstOrDefault() != null)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
  }
}
