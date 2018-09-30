using Help.EF;
using Help.Library;
using System.Linq;

namespace Help.WCFService.ArticleWCFService
{
  // HINWEIS: Mit dem Befehl "Umbenennen" im Menü "Umgestalten" können Sie den Klassennamen "ArticleWCFService" sowohl im Code als auch in der SVC- und der Konfigurationsdatei ändern.
  // HINWEIS: Wählen Sie zum Starten des WCF-Testclients zum Testen dieses Diensts ArticleWCFService.svc oder ArticleWCFService.svc.cs im Projektmappen-Explorer aus, und starten Sie das Debuggen.
  public class ArticleWCFService : IArticleWCFService
  {
    public string GetAll()
    {
      if (!HelpContext.IsInitialized)
      {
        HelpContext.InitInstance();
      }
      var qry = from a in HelpContext.Instance.Articles
                select a;
      return JSONSerializer.ObjectToJSON(qry.ToList());
    }

    public string GetByID(int value)
    {
      return "";
    }
  }
}