using System.Collections.Generic;
using System.Linq;

namespace Help.EF
{
  public class UserSettingService : HelpBaseService<UserSetting>
  {
    public override List<UserSetting> GetAllEntities()
    {
      var qry = from u in HelpContext.Instance.UserSettings
                select u;
      return qry.ToList();
    }

    public override UserSetting GetEntityByID(int id)
    {
      var qry = from u in HelpContext.Instance.UserSettings
                where u.ID_UserSetting == id
                select u;
      return qry.FirstOrDefault();
    }

    public UserSetting GetUserSettingFromSetting(int ID_Setting, int ID_User)
    {
      var qry = from u in HelpContext.Instance.UserSettings
                where u.Setting.ID_UserSetting == ID_Setting
                where u.User.ID_User == ID_User
                select u;
      UserSetting setting = qry.FirstOrDefault();
      return setting;
    }

    public UserSetting GetUserSettingFromName(string Name, int ID_User)
    {
      EFLogger.EFLog("Getting UserSetting for User " + ID_User + " Name: " + Name);
      var qry = from u in HelpContext.Instance.UserSettings
                where u.Setting.SettingName == Name
                where u.User.ID_User == ID_User
                select u;
      var res = qry.FirstOrDefault();
      if (res != null)
      {
        return res;
      }
      else
      {
        return null;
      }
    }

    public UserSetting GetUserSettingFromName(string Name, User user)
    {
      return GetUserSettingFromName(Name, user.ID_User);
    }
  }
}