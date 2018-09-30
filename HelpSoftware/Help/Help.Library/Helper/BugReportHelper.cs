using Help.EF;
using System;
using System.Linq;

namespace Help.Library
{
  public class BugReportHelper
  {
    public BugReportHelper()
    {
      AppContext.Logger.Debug("Init Instance Bug Report Helper");
    }

    public void SendBugMailNotification(BugReport report)
    {
      if (!AppContext.IsDevelopement)
      {
        AppContext.Logger.Info("Send E-Mail for Bug Report");
        SendEMailToAdmin(report);
        SendEMailToWriter(report);
        MarkBugReportAsNotified(report);
      }
    }

    private void MarkBugReportAsNotified(BugReport report)
    {
      report.Notified = true;
      report.NotfiyTime = DateTime.Now;
      HelpContext.Instance.SaveChanges();
    }

    private void SendEMailToWriter(BugReport report)
    {
      if (AppContext.IsLoggedIn)
      {
        string fullname = report.ReportUser.Vorname + " " + report.ReportUser.Nachname;
        string MailMessage = String.Format(EMailTemplates.UserBugReport, fullname, "#" + report.ID_BugReport + " " + report.ReportTitle, report.Report, report.Error);
        AppContext.MailHandlerInstance.SendPushEMail(MailMessage, "Bug Report #" + report.ReportTitle, report.ReportUser.EMail, EMailType.BugReport);
      }
    }

    private void SendEMailToAdmin(BugReport report)
    {
      var qry = from sys in HelpContext.Instance.SystemSettings
                where sys.Name == "AdminEMail"
                select sys;
      if (qry.FirstOrDefault() != null)
      {
        SystemSetting sys = qry.FirstOrDefault();
        if (sys.Value != null)
        {
          string request = "";
          if (AppContext.IsLoggedIn)
          {
            request = report.ReportUser.Vorname + " " + report.ReportUser.Nachname;
          }
          else
          {
            request = "Unknown Person";
          }
          string Mailmessage = String.Format(EMailTemplates.AdminBugReport, request, report.ReportTitle, report.Report, report.Error);
          AppContext.MailHandlerInstance.SendPushEMail(Mailmessage, "Error Report #" + report.ID_BugReport, sys.Value, EMailType.BugReport);
        }
      }
    }
  }
}