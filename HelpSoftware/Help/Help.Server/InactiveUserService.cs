using Help.EF;
using System;
using System.Linq;

namespace Help.Server
{
  public static class InactiveUserService
  {
    public static void DoService()
    {
      Program.WriteMessage("Check For Inactive User");
      var qry = from u in HelpContext.Instance.OpenConnections
                select u;
      Program.WriteMessage("Currently Are " + qry.Count() + " User Connected");
      foreach (var item in qry.ToList())
      {
        if (item.LastAction.AddHours(2) < DateTime.Now)
        {
          HelpContext.Instance.OpenConnections.Remove(item);
          Console.ForegroundColor = ConsoleColor.Blue;
          Program.WriteMessage("Removed Active User: Because no Activites");
          Program.WriteMessage(item.MachineName + " @IP " + item.IP);
          Console.ForegroundColor = ConsoleColor.White;
        }
      }
      HelpContext.Instance.SaveChanges();
    }
  }
}