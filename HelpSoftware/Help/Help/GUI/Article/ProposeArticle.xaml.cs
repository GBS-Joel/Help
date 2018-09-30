using Help.EF;
using Help.Library;
using System;
using System.Windows;

namespace Help
{
  public partial class ProposeArticle : HelpUserControl
  {
    public ProposeArticle()
    {
      InitializeComponent();
    }

    public override void DisplayData()
    {
      base.DisplayData();
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
      //await this.ShowMessageAsync("Thank you for your Help", "Thany You");
      //Close();
    }

    private void SendMailNotification(ArticleProposal prop)
    {
      string propname = "#" + prop.ID_ArticleProposal + " " + prop.ArticleTitle;
      string EMailMesasge = string.Format(EMailTemplates.RequesterProposedArticle, prop.RequesterName, propname, prop.ArticleDescription, prop.Comment);
      AppContext.MailHandlerInstance.SendPushEMail(EMailMesasge, "Thank you for Writing Proposal " + propname, prop.RequesterEMail, EMailType.ArticleProposal);
    }
  }
}