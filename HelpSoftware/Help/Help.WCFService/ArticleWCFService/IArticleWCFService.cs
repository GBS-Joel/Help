using System.ServiceModel;

namespace Help.WCFService.ArticleWCFService
{
  // HINWEIS: Mit dem Befehl "Umbenennen" im Menü "Umgestalten" können Sie den Schnittstellennamen "IArticleWCFService" sowohl im Code als auch in der Konfigurationsdatei ändern.
  [ServiceContract]
  public interface IArticleWCFService : IHelpEFService
  {
  }
}