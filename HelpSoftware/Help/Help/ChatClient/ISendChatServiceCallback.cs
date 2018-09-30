using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
  [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
  public interface ISendChatServiceCallback
  {

    [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "http://tempuri.org/ISendChatService/ReceiveMessage")]
    void ReceiveMessage(string msg, string receiver);

    [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "http://tempuri.org/ISendChatService/SendNames")]
    void SendNames(string[] names);
  }
}
