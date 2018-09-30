using Help.EF;
using Help.Library;
using System.Linq;

namespace Help.WCFService
{
  public class HelpService : IHelpService
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
  }
}