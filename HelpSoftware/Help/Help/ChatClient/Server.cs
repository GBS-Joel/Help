using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
  public class Server
  {
    public static ServiceHost host { get; set; }

    public void StartServer()
    {
      host = new ServiceHost(typeof(ChatService));
      host.Open();
    }
  }
}