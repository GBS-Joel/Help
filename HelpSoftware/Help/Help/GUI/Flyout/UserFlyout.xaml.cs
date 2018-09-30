using Help.EF;
using Help.Library;
using System;
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
      AppContext.BugReportHelperInstance.SendBugMailNotification(report);
      MessageBox.Show("Thank you for Sending this Bug Report");
      
    }
  }
}