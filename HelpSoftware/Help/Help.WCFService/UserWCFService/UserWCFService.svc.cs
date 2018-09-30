using Help.EF;
using Help.Library;
using System.Linq;

namespace Help.WCFService
{
  //RENAME TO SOMETHING DIFFERENT BECAUSE EF:USERSERVICE ALLREADY EXISTS
  //REMODEL TO USE USERSERVICEPROVIDER
  public class UserWCFService : IUserService
  {
    public string GetAll()
    {
      if (!HelpContext.IsInitialized)
      {
        HelpContext.InitInstance();
      }
      var qry = from u in HelpContext.Instance.Users
                select u;
      return JSONSerializer.ObjectToJSON(qry.ToList());
    }

    public string GetByID(int value)
    {
      if (!HelpContext.IsInitialized)
      {
        HelpContext.InitInstance();
      }
      var qry = from u in HelpContext.Instance.Users
                where u.ID_User == value
                select u;
      return JSONSerializer.ObjectToJSON(qry.FirstOrDefault());
    }

    public string GetUserByNick(string Nick)
    {
      if (!HelpContext.IsInitialized)
      {
        HelpContext.InitInstance();
      }
      var qry = from u in HelpContext.Instance.Users
                where u.Nick == Nick
                select u;
      return JSONSerializer.ObjectToJSON(qry.FirstOrDefault());
    }
  }
}