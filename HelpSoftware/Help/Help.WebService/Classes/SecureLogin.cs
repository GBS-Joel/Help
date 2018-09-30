using Help.EF;
using System.Linq;

namespace Help.WebService
{
  public class SecureLogin
  {
    public SecureLogin()
    {
    }

    public string LogIn(string Username, string Password)
    {
      var qry = from u in HelpContext.Instance.Users
                where u.Username == Username
                select u;
      if (qry.FirstOrDefault().Password == Password)
      {
        return GenerateToken();
      }
      else
      {
        return "";
      }
    }

    private string GenerateToken()
    {
      return "";
    }
  }
}