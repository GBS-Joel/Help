using Help.EF;
using System;
using System.Linq;

namespace Help.Library
{
  public class RegisterHandler
  {
    public void Registrate(User User)
    {
      var qry = from u in HelpContext.Instance.Users
                where u.Username == User.Username
                select u;
      if (qry.FirstOrDefault() == null)
      {
        User.Password = HashGenerator.Hash(User.Password);
        User.Birth = DateTime.Now;
        HelpContext.Instance.Users.Add(User);
        HelpContext.Instance.SaveChanges();
        HelpContext.Instance.Entry(User).Reload();
        AppContext.MailHandlerInstance.SendActivationEMail(User);
        AppContext.HelpSettingsHandler.UserSettingsHandler.UserSettingsValidator.ValidateAndRestoreUserSettingsForUser(User);

        AppContext.LoginHandlerInstance.CreateConfFile(User.Username, User.Password);
      }
    }
  }
}