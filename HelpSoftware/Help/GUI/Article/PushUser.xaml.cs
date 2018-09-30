using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Help
{
  public partial class PushUser : MetroWindow
  {
    public PushUser()
    {
      InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      User nomuser = (User)cbUsers.SelectedItem;
      ArticleNomination nom = new ArticleNomination()
      {
        ArticleDescription = tbArtDesc.Text,
        ArticleTitle = tbArticleTitle.Text,
        Comment = Comment.Text,
        NominationedDate = DateTime.Now,
        RequestedUser = AppContext.LoggedInUser,
        NominatedUser = nomuser
      };
      HelpContext.Instance.ArticleNominations.Add(nom);
      HelpContext.Instance.SaveChanges();
      SendPushMail(nom);
    }

    private void SendPushMail(ArticleNomination nom)
    {
      string FullNameRecipient = nom.NominatedUser.Vorname + " " + nom.NominatedUser.Nachname;
      string FullNameRequester = nom.RequestedUser.Vorname + " " + nom.RequestedUser.Nachname;
      string MailMessage = String.Format(EMailTemplates.NominatedForArticle, FullNameRecipient,
                               FullNameRequester, nom.ArticleTitle, nom.ArticleDescription,
                               nom.Comment);
      MailHandler.Instance.SendPushEMail(MailMessage, "You have been Nominated to write Article " + nom.ArticleTitle, nom.NominatedUser.EMail, EMailType.Nominated);
    }


    private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
    {
      var qry = from us in HelpContext.Instance.Users
                where us.IsActive == true
                where us.Username != AppContext.LoggedInUser.Username
                select us;
      List<User> users = qry.ToList();
      cbUsers.ItemsSource = users;
    }
  }
}