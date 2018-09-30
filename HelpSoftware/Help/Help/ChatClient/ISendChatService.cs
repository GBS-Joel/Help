using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Help
{
  [ServiceContract(CallbackContract = typeof(IReceiveChatService))]
  public interface ISendChatService
  {
    [OperationContract(IsOneWay = true)]
    void SendMessage(string msg, string sender, string receiver);
    [OperationContract(IsOneWay = true)]
    void Start(string Name);
    [OperationContract(IsOneWay = true)]
    void Stop(string Name);
  }
}