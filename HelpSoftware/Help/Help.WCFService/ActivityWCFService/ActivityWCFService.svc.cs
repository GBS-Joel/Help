using System;

namespace Help.WCFService.ActivityWCFService
{
  // HINWEIS: Mit dem Befehl "Umbenennen" im Menü "Umgestalten" können Sie den Klassennamen "ActivityWCFService" sowohl im Code als auch in der SVC- und der Konfigurationsdatei ändern.
  // HINWEIS: Wählen Sie zum Starten des WCF-Testclients zum Testen dieses Diensts ActivityWCFService.svc oder ActivityWCFService.svc.cs im Projektmappen-Explorer aus, und starten Sie das Debuggen.
  public class ActivityWCFService : IActivityWCFService
  {
    public void DoWork()
    {
    }

    public string GetAll()
    {
      throw new NotImplementedException();
    }

    public string GetByID(int value)
    {
      throw new NotImplementedException();
    }
  }
}