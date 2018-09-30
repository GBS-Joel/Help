using System.Collections.Generic;
using System.Linq;

namespace Help.EF
{
  public class UserService : HelpBaseService<User>
  {
    public UserService() : base()
    {

    }

    public List<User> GetUsersFromUserName(string Username)
    {
      var qry = from u in HelpContext.Instance.Users
                where u.Username == Username
                select u;
      return qry.ToList();
    }

    public override User GetEntityByID(int id)
    {
      throw new System.NotImplementedException();
    }

    public override List<User> GetAllEntities()
    {
      var qry = from u in HelpContext.Instance.Users
                select u;
      return qry.ToList();
    }
  }
}