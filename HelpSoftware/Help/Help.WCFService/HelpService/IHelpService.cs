using System.ServiceModel;

namespace Help.WCFService
{
  [ServiceContract]
  public interface IHelpService
  {
    [OperationContract]
    string GetByID(int value);

    [OperationContract]
    string GetAll();
  }
}