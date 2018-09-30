using System.ServiceModel;

namespace Help.WCFService.TagWCFService
{
  // HINWEIS: Mit dem Befehl "Umbenennen" im Menü "Umgestalten" können Sie den Schnittstellennamen "ITagWCFService" sowohl im Code als auch in der Konfigurationsdatei ändern.
  [ServiceContract]
  public interface ITagWCFService : IHelpEFService
  {
  }
}