using System;

namespace Help.Library
{
  public class HelpException : Exception
  {
    public HelpException(string Message) : base(Message)
    {
    }

    public HelpException()
    {
    }
  }
}