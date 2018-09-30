using System.ServiceModel;

namespace Help.WCFService.ActivityWCFService
{
  [ServiceContract]
  public interface IActivityWCFService : IHelpEFService
  {
    [OperationContract]
    void DoWork();
  }
}