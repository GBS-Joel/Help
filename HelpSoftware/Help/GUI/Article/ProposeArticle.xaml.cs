using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Windows;

namespace Help
{
  public partial class ProposeArticle : MetroWindow
  {
    public ProposeArticle()
    {
      InitializeComponent();
    }

    private async void btnSave_Click(object sender, RoutedEventArgs e)
    {
      ArticleProposal prop = new ArticleProposal()
      {
        ArticleTitle = tbArticleTitle.Text,
        ArticleDescription = tbArtDesc.Text,
        AssignedUser = null,
        Comment = tbComment.Text,
        RequesterName = tbUsername.Text,
        CreatedDate = DateTime.Now,
        RequesterEMail = tbEMail.Text
      };
      HelpContext.Instance.ArticleProposals.Add(prop);
      HelpContext.Instance.SaveChanges();
      HelpContext.Instance.Entry(prop).Reload();
      SendMailNotification(prop);
      await this.ShowMessageAsync("Thank you for your Help", "Thany You");
      Close();
    }

    private void SendMailNotification(ArticleProposal prop)
    {
      string propname = "#" + prop.ID_ArticleProposal + " " + prop.ArticleTitle;
      string EMailMesasge = string.Format(EMailTemplates.RequesterProposedArticle, prop.RequesterName, propname, prop.ArticleDescription, prop.Comment);
      MailHandler.Instance.SendPushEMail(EMailMesasge, "Thank you for Writing Proposal " + propname, prop.RequesterEMail, EMailType.ArticleProposal);
    }
  }
}