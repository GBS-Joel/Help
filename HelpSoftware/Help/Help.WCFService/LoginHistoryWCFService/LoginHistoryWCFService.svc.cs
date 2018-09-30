using Help.EF;
using Help.Library;
using System;
using System.Linq;

namespace Help.WCFService.LoginHistoryWCFService
{
  // HINWEIS: Mit dem Befehl "Umbenennen" im Menü "Umgestalten" können Sie den Klassennamen "LoginHistoryWCFService" sowohl im Code als auch in der SVC- und der Konfigurationsdatei ändern.
  // HINWEIS: Wählen Sie zum Starten des WCF-Testclients zum Testen dieses Diensts LoginHistoryWCFService.svc oder LoginHistoryWCFService.svc.cs im Projektmappen-Explorer aus, und starten Sie das Debuggen.
  public class LoginHistoryWCFService : ILoginHistoryWCFService
  {
    public string GetAll()
    {
      throw new NotImplementedException();
    }

    public string GetByID(int value)
    {
      throw new NotImplementedException();
    }

    public string GetLoginInfoByUser(int ID)
    {
      if (!HelpContext.IsInitialized)
      {
        HelpContext.InitInstance();
      }
      var qry = from h in HelpContext.Instance.LoginHistorys
                where h.LoggedInUser.ID_User == ID
                select h;
      return JSONSerializer.ObjectToJSON(qry.ToList());
    }
  }
}