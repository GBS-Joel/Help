using System.Collections.Generic;
using System.ServiceModel;

namespace Help
{
  public interface IReceiveChatService
  {
    [OperationContract(IsOneWay = true)]
    void ReceiveMessage(string msg, string receiver);

    [OperationContract(IsOneWay = true)]
    void SendNames(List<string> names);
  }
}