using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Help
{
  public class LoginHelper
  {
    public static LoginHelper Instance { get; set; }

    public static void Initalize()
    {
      Instance = new LoginHelper();
    }

    public bool TryLogin(string Username, string PW, LoginType Type)
    {
      var qry = from user in HelpContext.Instance.Users
                where user.Username == Username
                select user;
      User u = qry.FirstOrDefault();
      if (HashGenerator.Verify(PW, u.Password))
      {
        AppContext.LoggedInUser = u;
        AppContext.IsLoggedIn = true;
        LoginHistory h = new LoginHistory()
        {
          LoggedInTime = DateTime.Now,
          LoggedInUser = u
        };
        HelpContext.Instance.LoginHistorys.Add(h);
        HelpContext.Instance.SaveChanges();
        return true;
      }
      else
      {
        MessageBox.Show("Loggin Failed");
        return false;
      }
    }

    private void WriteLoginHistory()
    {

    }
  }
}