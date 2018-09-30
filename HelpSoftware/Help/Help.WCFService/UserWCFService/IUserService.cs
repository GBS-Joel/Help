using System.ServiceModel;

namespace Help.WCFService
{
  [ServiceContract]
  public interface IUserService : IHelpEFService
  {
    [OperationContract]
    string GetUserByNick(string Nick);
  }
}