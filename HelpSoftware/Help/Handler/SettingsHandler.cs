using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
  public class SettingsHandler
  {
    public static SettingsHandler Instance { get; private set; }

    private SettingsHandler()
    {

    }

    public static void InitInstance()
    {
      Instance = new SettingsHandler();
      Instance.UpdateSettings();
      Instance.SyncDatabaseWithSystemSettings();
    }

    private void UpdateSettings()
    {
      //List of Settings
      //1--> AppColor // Application Theme on startup -> Combobox Name: AppColor
      //2--> Random App Theme on Startup --> Overrides the first one // 
      //-> switch // enable disable 1 
      //3--> Send Email when a user likes your Article
      //4--> send EMail when a user favorites your article
      if (!CheckIfSettingExists("AppTheme"))
        CreateSetting("AppTheme", "1");

      if (!CheckIfSettingExists("RandomAppTheme"))
        CreateSetting("RandomAppTheme", "1");

      if (!CheckIfSettingExists("SendNotfificationOnArticleLiked"))
        CreateSetting("SendNotfificationOnArticleLiked", "1");

      if (!CheckIfSettingExists("SendNotfificationOnArticleFavorited"))
        CreateSetting("SendNotfificationOnArticleFavorited", "1");
    }

    public void CreateSettingsForUser(User u)
    {
      LoadSettingAndCreateSetting("AppTheme", "1", u);
      LoadSettingAndCreateSetting("RandomAppTheme", "1", u);
      LoadSettingAndCreateSetting("SendNotfificationOnArticleLiked", "1", u);
      LoadSettingAndCreateSetting("SendNotfificationOnArticleFavorited", "1", u);
    }

    public void LoadSettingAndCreateSetting(string Settingname, string val, User u)
    {
      var qry = from set in HelpContext.Instance.Settings
                where set.SettingName == Settingname
                select set;
      Setting s = qry.FirstOrDefault();
      CreateUserSetting(u, s, val);
    }

    public void CreateUserSetting(User u, Setting s, string Val)
    {
      UserSetting setting = new UserSetting()
      {
        Created = DateTime.Now,
        LastChanged = DateTime.Now,
        Setting = s,
        User = u,
        UserValue = Val
      };
      HelpContext.Instance.UserSettings.Add(setting);
      HelpContext.Instance.SaveChanges();
    }

    public void CreateSetting(string SName, string DValue)
    {
      Setting s = new Setting()
      {
        SettingName = SName,
        DefaultValue = DValue,
        Created = DateTime.Now
      };
      HelpContext.Instance.Settings.Add(s);
      HelpContext.Instance.SaveChanges();
    }

    public bool CheckIfSettingExists(string SettingName)
    {
      var qry = from set in HelpContext.Instance.Settings
                where set.SettingName == SettingName
                select set;
      if (qry.FirstOrDefault() != null)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

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

    public Setting GetSettingFromName(string Name)
    {
      if (Name != null)
      {
        var qry = from set in HelpContext.Instance.Settings
                  where set.SettingName == Name
                  select set;
        return qry.FirstOrDefault();
      }
      else
      {
        return null;
      }
    }
  }
}