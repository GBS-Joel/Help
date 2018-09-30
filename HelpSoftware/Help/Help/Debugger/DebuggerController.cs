using Help.Library;
using System;
using System.Linq;
using System.Windows.Controls;

namespace Help.Debugger
{
  //Gathers info from the Context Class
  public class DebuggerController
  {
    public TextBox Output { get; set; }

    //Reference to the Client
    public DebuggerController(TextBox Output)
    {
      this.Output = Output;
    }

    public void WriteDebug(string Message)
    {
      Output.AppendText(DateTime.Now + "\t " + Message);
    }

  
    public ClientInfo GetClientInfo()
    {
      return AppContext.ClientInfo ?? new ClientInfo();
    }
  }
}