using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
  [System.Diagnostics.DebuggerStepThroughAttribute()]
  [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
  public partial class SendChatServiceClient : System.ServiceModel.DuplexClientBase<Client.ChatService.ISendChatService>, Client.ChatService.ISendChatService
  {

    public SendChatServiceClient(System.ServiceModel.InstanceContext callbackInstance) :
            base(callbackInstance)
    {
    }

    public SendChatServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) :
            base(callbackInstance, endpointConfigurationName)
    {
    }

    public SendChatServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) :
            base(callbackInstance, endpointConfigurationName, remoteAddress)
    {
    }

    public SendChatServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(callbackInstance, endpointConfigurationName, remoteAddress)
    {
    }

    public SendChatServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(callbackInstance, binding, remoteAddress)
    {
    }

    public void SendMessage(string msg, string sender, string receiver)
    {
      base.Channel.SendMessage(msg, sender, receiver);
    }

    public void Start(string Name)
    {
      base.Channel.Start(Name);
    }

    public void Stop(string Name)
    {
      base.Channel.Stop(Name);
    }
  }
}
