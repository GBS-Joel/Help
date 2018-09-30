using System.Collections.Generic;
using System.Linq;
using Help.EF;
using Help.Library;

namespace Help
{
  public class UserProfileOwnModel : BaseModel<UserProfileOwnModel>
  {
    public User CurrentUser { get; set; }

    public List<Activity> Activites { get; set; }

    public List<UserSetting> UserSettings { get; set; }

    public string AuthorName { get; set; }

    public string NewPassword { get; set; }

    public UserProfileOwnModel(User User)
    {
      CurrentUser = User;
      Activites = new List<Activity>();
    }

    public override void LoadData()
    {
      base.LoadData();
      LoadUserActivity();
      LoadPinWall();
      LoadUserSettings();
      AuthorName = CurrentUser.Vorname + " " + CurrentUser.Nachname;
    }

    public void LoadUserSettings()
    {
      var qry = from s in HelpContext.Instance.UserSettings
                where s.User.ID_User == CurrentUser.ID_User
                select s;
      UserSettings = qry.ToList();
    }

    public void LoadUserActivity()
    {
      var qry = from act in HelpContext.Instance.Activities
                where act.ActivityUser.ID_User == CurrentUser.ID_User
                orderby act.ActivityOn descending
                select act;
      Activites = qry.ToList();
    }

    public void LoadPinWall()
    {
      var qry = from pw in HelpContext.Instance.PinWallComments
                where pw.User.ID_User == CurrentUser.ID_User
                where pw.IsPublic == true
                select pw;
    }

    public override IModuleElement Owner { get; set; }

    public UserProfileOwnModel ModelInstance { get; set; }

    public void SaveUserProfile()
    {
      if (NewPassword != "" && NewPassword != null)
      {
        CurrentUser.Password = HashGenerator.Hash(NewPassword);
      }
      HelpContext.Instance.SaveChanges();
    }

    public void SaveUserSettings()
    {

    }

    public override int GetID()
    {
      return CurrentUser.ID_User;
    }
  }
}