using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Help
{
  public partial class UserFlyout : UserControl
  {
    public UserFlyout()
    {
      InitializeComponent();
    }

    private void btnSendReport_Click(object sender, RoutedEventArgs e)
    {
      BugReport report = new BugReport()
      {
        Error = tbErrorCode.Text,
        Report = Description.Text,
        ReportTime = DateTime.Now,
        ReportTitle = tbTitle.Text,
        ReportUser = AppContext.LoggedInUser
      };
      HelpContext.Instance.BugReports.Add(report);
      HelpContext.Instance.SaveChanges();
      HelpContext.Instance.Entry(report).Reload();
      SendMailNotficitations(report);
    }

    public void SendMailNotficitations(BugReport report)
    {
      SendMailToWriter(report);
      SendMailToAdmin(report);
    }

    private void SendMailToWriter(BugReport report)
    {
      if (AppContext.IsLoggedIn)
      {
        string fullname = report.ReportUser.Vorname + " " + report.ReportUser.Nachname;
        string MailMessage = String.Format(EMailTemplates.UserBugReport, fullname, "#" + report.ID_BugReport + " " + report.ReportTitle, report.Report, report.Error);
        MailHandler.Instance.SendPushEMail(MailMessage, "Bug Report #" + report.ReportTitle, report.ReportUser.EMail, EMailType.BugReport);
      }
    }

    private void SendMailToAdmin(BugReport report)
    {
      var qry = from sys in HelpContext.Instance.SystemSettings
                where sys.Name == SystemSettings.AdminEMail.ToString()
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
          MailHandler.Instance.SendPushEMail(Mailmessage, "Error Report #" + report.ID_BugReport, sys.Value, EMailType.BugReport);
        }
      }
    }
  }
}