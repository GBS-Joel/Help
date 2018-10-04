using Help.EF;
using System;
using System.Linq;

namespace Help.Library
{
  public class SettingsHandler
  {
    public UserSettingsHandler UserSettingsHandler { get; set; }

    public SettingsHandler()
    {
      UserSettingsHandler = new UserSettingsHandler();
      UpdateSettings();

    }

    private void UpdateSettings()
    {
      //List of Settings
      //1--> AppColor // Application Theme on startup -> Combobox Name: AppColor
      //2--> Random App Theme on Startup --> Overrides the first one //
      //-> switch // enable disable 1
      //3--> Send Email when a user likes your Article
      //4--> send EMail when a user favorites your article
      //5--> Dark Theme on Window
      if (!CheckIfSettingExists("AppTheme"))
        CreateSetting("AppTheme", "1");

      if (!CheckIfSettingExists("RandomAppTheme"))
        CreateSetting("RandomAppTheme", "1");

      if (!CheckIfSettingExists("SendNotfificationOnArticleLiked"))
        CreateSetting("SendNotfificationOnArticleLiked", "1");

      if (!CheckIfSettingExists("SendNotfificationOnArticleFavorited"))
        CreateSetting("SendNotfificationOnArticleFavorited", "1");

      if (!CheckIfSettingExists("UseDarkTheme"))
        CreateSetting("UseDarkTheme", "1");
    }

    public void CreateSettingsForUser(User u)
    {
      LoadSettingAndCreateSetting("AppTheme", "1", u);
      LoadSettingAndCreateSetting("RandomAppTheme", "1", u);
      LoadSettingAndCreateSetting("SendNotfificationOnArticleLiked", "1", u);
      LoadSettingAndCreateSetting("SendNotfificationOnArticleFavorited", "1", u);
      LoadSettingAndCreateSetting("UseDarkTheme", "1", u);
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