using System.ServiceModel;

namespace Help.WCFService.LoginHistoryWCFService
{
  // HINWEIS: Mit dem Befehl "Umbenennen" im Menü "Umgestalten" können Sie den Schnittstellennamen "ILoginHistoryWCFService" sowohl im Code als auch in der Konfigurationsdatei ändern.
  [ServiceContract]
  public interface ILoginHistoryWCFService : IHelpEFService
  {
    [OperationContract]
    string GetLoginInfoByUser(int ID);
  }
}