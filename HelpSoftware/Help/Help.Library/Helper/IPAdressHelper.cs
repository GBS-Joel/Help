using System.Net;
using System.Net.Sockets;

namespace Help.Library
{
  public static class IPAdressHelper
  {
    public static string GetLocalIPAddress()
    {
      var host = Dns.GetHostEntry(Dns.GetHostName());
      foreach (var ip in host.AddressList)
      {
        if (ip.AddressFamily == AddressFamily.InterNetwork)
        {
          return ip.ToString();
        }
      }
      throw new HelpException("No network adapters with an IPv4 address in the system!");
    }
  }
}