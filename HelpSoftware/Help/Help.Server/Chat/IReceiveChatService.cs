using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Help.Server
{
  public interface IReceiveChatService
  {
    [OperationContract(IsOneWay = true)]
    void ReceiveMessage(string msg, string receiver);
    [OperationContract(IsOneWay = true)]
    void SendNames(List<string> names);
  }
}