using Help.EF;
using Help.Library;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Help
{
  public partial class ReportWrongTranslation : UserControl
  {
    public ReportWrongTranslation()
    {
      InitializeComponent();
    }

    private void btnSendReport_Click(object sender, RoutedEventArgs e)
    {
      WrongTranslation wrong = new WrongTranslation()
      {
        Author = AppContext.LoggedInUser,
        Created = DateTime.Now,
        WrongText = tbWrongText.Text,
        NewText = tbNewText.Text,
        Description = tbDescription.Text
      };
      HelpContext.Instance.WrongTranslations.Add(wrong);
      HelpContext.Instance.SaveChanges();

      SendEMail(wrong);
    }

    public void SendEMail(WrongTranslation wrong)
    {
    }
  }
}