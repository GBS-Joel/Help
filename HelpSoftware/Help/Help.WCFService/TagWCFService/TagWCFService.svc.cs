using Help.EF;
using Help.Library;
using System;
using System.Linq;

namespace Help.WCFService.TagWCFService
{
  // HINWEIS: Mit dem Befehl "Umbenennen" im Menü "Umgestalten" können Sie den Klassennamen "TagWCFService" sowohl im Code als auch in der SVC- und der Konfigurationsdatei ändern.
  // HINWEIS: Wählen Sie zum Starten des WCF-Testclients zum Testen dieses Diensts TagWCFService.svc oder TagWCFService.svc.cs im Projektmappen-Explorer aus, und starten Sie das Debuggen.
  public class TagWCFService : ITagWCFService
  {
    public string GetAll()
    {
      if (!HelpContext.IsInitialized)
      {
        HelpContext.InitInstance();
      }
      var qry = from t in HelpContext.Instance.Tags
                select t;
      return JSONSerializer.ObjectToJSON(qry.ToList());
    }

    public string GetByID(int value)
    {
      throw new NotImplementedException();
    }
  }
}