using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Library
{
  class WerteBereichNotValidException : HelpException
  {
    public WerteBereichNotValidException()
    {
    }

    public WerteBereichNotValidException(string Message) : base(Message)
    {
    }
  }
}
