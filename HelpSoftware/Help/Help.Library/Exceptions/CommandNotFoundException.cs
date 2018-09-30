using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Library
{
  public class CommandNotFoundException : HelpException
  {
    public CommandNotFoundException(string Message) : base("Der Command mit dem Schlüssel " + Message + "' konnte nicht gefunden werden!")
    {
    }

    public CommandNotFoundException() : base()
    {
    }
  }
}