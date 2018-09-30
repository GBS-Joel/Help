using System.ServiceModel;

namespace Help.WCFService
{
  [ServiceContract]
  public interface IHelpEFService
  {
    [OperationContract]
    string GetByID(int value);

    [OperationContract]
    string GetAll();
  }
}