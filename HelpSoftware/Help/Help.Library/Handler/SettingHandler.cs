using Help.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Help.Library
{
  public class SettingHandler
  {
    //Try after auto Login and After Database is initialzed
    public SettingHandler()
    {
      IsInitialized = true;
      UserSettings = new List<UserSetting>();
      SystemSettings = new List<SystemSetting>();
      CreateDefaultSystemSettings();
      CreateDefaultSettings();
    }

    //If Not Logged in you can use those settings. These get discared if the App gets closed or the user gets logged in
    public static List<UserSetting> LocalUserSettings { get; set; }

    private void CreateDefaultSettings()
    {
      CreateSettingIfNotExists("AppLanguage", "1");
    }

    private void CreateSettingIfNotExists(string name, string DefaultValue)
    {
      if (!CheckIfSettingsExists(name))
        SaveSetting(CreateSetting(name, DefaultValue));
    }

    private void SaveSetting(Setting setting)
    {
      HelpContext.Instance.Settings.Add(setting);
      HelpContext.Instance.SaveChanges();
    }

    private Setting CreateSetting(string Name, string DefaultValue)
    {
      return new Setting()
      {
        DefaultValue = DefaultValue,
        Created = DateTime.Now,
        SettingName = Name
      };
    }

    private bool CheckIfSettingsExists(string Name)
    {
      var qry = from s in HelpContext.Instance.Settings
                where s.SettingName == Name
                select s;
      return qry.FirstOrDefault() != null;
    }

    private List<UserSetting> UserSettings { get; set; }

    private List<SystemSetting> SystemSettings { get; set; }

    public SystemSetting GetSystemSettingFromName(string Name)
    {
      if (HelpContext.IsInitialized)
      {
        var qry = from s in HelpContext.Instance.SystemSettings
                  where s.Name == Name
                  select s;
        SystemSetting setting = qry.FirstOrDefault();
        if (setting != null)
        {
          return setting;
        }
        else
        {
          throw new SystemSettingNotFoundException(Name);
        }
      }
      else
      {
        //throw new HandlerNotInitializedException();
        return null;
      }
    }

    public bool IsInitialized { get; set; }

    //Call After Login
    public void ReloadSettingsAfterLogin()
    {
      var qry = from s in HelpContext.Instance.SystemSettings
                select s;
      SystemSettings = qry.ToList();
    }

    //Call after
    public void ReloadSystemSettings()
    {
      if (HelpContext.IsInitialized)
      {
        HelpContext.Instance.Dispose();
        HelpContext.InitInstance();
        var qry = from u in HelpContext.Instance.SystemSettings
                  select u;
        SystemSettings = qry.ToList();
      }
    }

    //List of all System Settings
    //Magnitude
    //DefaultLoginFilePath --> Rename to ConfFile
    //IsDevelopement
    //IsDebugModeEnabled
    //LogFilePath
    private void CreateDefaultSystemSettings()
    {
      CreateSystemSettingIfNotExists("IsDevelopementMode", "0");
      CreateSystemSettingIfNotExists("IsDevelopement", "0");
      CreateSystemSettingIfNotExists("IsDebugModeEnabled", "0");
      CreateSystemSettingIfNotExists("LogFilePath", @"C:\Help\log.txt");
      CreateSystemSettingIfNotExists("DefaultLoginFilePath", @"C:\Help\Login.txt");
      CreateSystemSettingIfNotExists("FirstStartUp", @"1");
    }

    private bool CheckIfSystemSettingExists(string Name)
    {
      var qry = from s in HelpContext.Instance.SystemSettings
                where s.Name == Name
                select s;
      return qry.FirstOrDefault() != null;
    }

    private void CreateSystemSettingIfNotExists(string Name, string DefaulValue)
    {
      if (!CheckIfSystemSettingExists(Name))
        SaveSystemSetting(CreateSystemSetting(Name, DefaulValue));
    }

    private void SaveSystemSetting(SystemSetting Setting)
    {
      if (!HelpContext.IsInitialized)
        HelpContext.InitInstance();
      HelpContext.Instance.SystemSettings.Add(Setting);
      HelpContext.Instance.SaveChanges();
    }

    private SystemSetting CreateSystemSetting(string Name, string DefaultValue)
    {
      return new SystemSetting()
      {
        Created = DateTime.Now,
        Name = Name,
        Value = DefaultValue
      };
    }

    public void SystemSettingNotFound(string Name)
    {
      AppContext.Logger.Warn("System Setting Not Found", Name);
    }
  }
}