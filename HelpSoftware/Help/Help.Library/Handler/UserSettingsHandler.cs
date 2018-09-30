using Help.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Library
{
  public class UserSettingsHandler
  {
    public UserSettingsValidator UserSettingsValidator { get; set; }

    public UserSettingsHandler()
    {
      UserSettingsValidator = new UserSettingsValidator();
    }

    public void CreateUserSettingsForUser(User user)
    {
      UserSettingsValidator.ValidateAndRestoreUserSettingsForUser(user);
    }

    public void ValidateUserSettings(User user)
    {
      UserSettingsValidator.ValidateAndRestoreUserSettingsForUser(user);
    }

    public UserSetting GetUserSettingFromName(string Name)
    {
      var qry = from u in HelpContext.Instance.UserSettings
                where u.User.ID_User == AppContext.LoggedInUser.ID_User
                where u.Setting.SettingName == Name
                select u;
      return qry.FirstOrDefault();
    }

    public void SetUserSetting(string Name, string Value)
    {
      var qry = from u in HelpContext.Instance.UserSettings
                where u.Setting.SettingName == Name
                select u;
      UserSetting set = qry.FirstOrDefault();
      if (set != null)
      {
        set.UserValue = "1";
      }
      else
      {
        var qry1 = from s in HelpContext.Instance.Settings
                   where s.SettingName == Name
                   select s;
        Setting setting = qry1.FirstOrDefault();
        if (setting != null)
        {
          UserSetting usersetting = new UserSetting()
          {
            Created = DateTime.Now,
            LastChanged = DateTime.Now,
            Setting = setting,
            User = AppContext.LoggedInUser,
            UserValue = "1"
          };
          HelpContext.Instance.UserSettings.Add(usersetting);
          HelpContext.Instance.SaveChanges();
        }
        else
        {
          throw new SystemSettingNotFoundException(Name);
        }
      }
      HelpContext.Instance.SaveChanges();
    }
  }
}