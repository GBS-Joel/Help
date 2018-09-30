using Help.EF;
using Help.Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Help.Server
{
  public static class BugReportsService
  {
    public static void DoService()
    {
      Program.WriteMessage("Check for Pending Bug Reports");
      var qry = from b in HelpContext.Instance.BugReports
                where b.Notified == false
                select b;
      List<BugReport> reports = new List<BugReport>();
      reports = qry.ToList();
      Program.WriteMessage("There are " + reports.Count + " Not Notified Bug Reports");
      if (reports.Count > 0)
      {
        Console.ForegroundColor = ConsoleColor.Blue;
        Program.WriteMessage("Sending Bug Report");
        Console.ForegroundColor = ConsoleColor.White;
      }
      foreach (var item in reports)
      {
        AppContext.BugReportHelperInstance.SendBugMailNotification(item);
      }
    }
  }
}