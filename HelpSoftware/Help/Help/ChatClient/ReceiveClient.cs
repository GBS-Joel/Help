using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
  public delegate void ReceviedMessage(string sender, string message);
  public delegate void GotNames(object sender, List<string> names);

  class ReceiveClient : ISendChatServiceCallback
  {
    public event ReceviedMessage ReceiveMsg;
    public event GotNames NewNames;

    InstanceContext inst = null;
    SendChatServiceClient chatClient = null;

    public void Start(ReceiveClient rc, string name)
    {
      inst = new InstanceContext(rc);
      chatClient = new SendChatServiceClient(inst);
      chatClient.Start(name);
    }

    public void SendMessage(string msg, string sender, string receiver)
    {
      chatClient.SendMessage(msg, sender, receiver);
    }

    public void Stop(string name)
    {
      chatClient.Stop(name);
    }

    void ISendChatServiceCallback.ReceiveMessage(string msg, string receiver)
    {
      if (ReceiveMsg != null)
        ReceiveMsg(receiver, msg);
    }

    public void SendNames(string[] names)
    {
      if (NewNames != null)
        NewNames(this, names.ToList());
    }
  }
}