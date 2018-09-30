using System;

namespace Help.EF
{
  public static class Connection
  {
    public static string ConnectionString
    {
      get
      {
        if (Environment.MachineName == "W10-JM")
        {
          return @"server=W10-JM;initial catalog =Help; Integrated Security = true";
        }
        else if (Environment.MachineName == "PC-JOËL")
        {
          return @"server=PC-JOËL\PCJOEL;initial catalog =Help; Integrated Security = true";
        }
        else
        {
          return "";
        }
      }
      private set { }
    }
  }
}