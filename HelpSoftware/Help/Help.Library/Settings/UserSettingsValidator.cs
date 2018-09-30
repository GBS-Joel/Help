using Help.EF;
using System;

namespace Help.Library
{
  public class UserSettingsValidator
  {
    //Checks if the user has all the Settings and the Right Value
    //This needs to be done to provide updateless programming
    //If The User does not log in for a long Time and new Setings come
    public void ValidateAndRestoreUserSettingsForUser(User User)
    {
      foreach (var item in HelpService.GetService<SettingService>().GetAllEntities())
      {
        CheckIfUserSettingExistsAndCreate(item);
      }
    }

    private void CheckIfUserSettingExistsAndCreate(Setting setting)
    {
      var res = HelpService.GetService<UserSettingService>().GetUserSettingFromSetting(setting.ID_UserSetting, AppContext.LoggedInUser.ID_User);
      if (res == null)
      {
        CreateUserSetting(setting);
      }
    }

    private void CreateUserSetting(Setting setting)
    {
      UserSetting set = new UserSetting()
      {
        Created = DateTime.Now,
        LastChanged = DateTime.Now,
        Setting = setting,
        User = AppContext.LoggedInUser,
        UserValue = setting.DefaultValue,
      };
      HelpContext.Instance.UserSettings.Add(set);
      HelpContext.Instance.SaveChanges();
    }

    private void RestoreUserSetting(Setting setting, User user)
    {
      UserSetting usersetting = new UserSetting()
      {
        Created = DateTime.Now,
        LastChanged = DateTime.Now,
        User = user,
        Setting = setting,
        UserValue = setting.DefaultValue
      };
      HelpContext.Instance.UserSettings.Add(usersetting);
      HelpContext.Instance.SaveChanges();
    }
  }
}