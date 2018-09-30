using Help.EF;
using Help.Library;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Help
{
  public partial class CommentListBoxItem : ListBoxItem
  {
    public ArticleComment CurrentComment { get; set; }

    public string CommentAuthor { get; set; }

    public bool IsAuthorKnown { get; set; }

    public string OldCommentValue { get; set; }

    public string OldCommentTitleValue { get; set; }

    public CommentListBoxItem()
    {
      InitializeComponent();
    }

    public CommentListBoxItem(ArticleComment Comment)
    {
      InitializeComponent();
      CurrentComment = Comment;
      LoadComment();
      DataContext = this;
      if (IsAuthorKnown)
      {
        imgUser.MouseDown += MouseOnDown;
        tbuser.MouseDown += MouseOnDown;
        imgUser.Cursor = Cursors.Hand;
        tbuser.Cursor = Cursors.Hand;
      }
      if (CheckCanEdit())
      {
        btnEdit.Visibility = Visibility.Visible;
      }
      OldCommentTitleValue = CurrentComment.CommentTitle;
      OldCommentValue = CurrentComment.Comment;
    }

    private void MouseOnDown(object sender, MouseButtonEventArgs e)
    {
      if (CurrentComment.UserComment.ID_User == AppContext.LoggedInUser.ID_User)
      {
        AppContext.WindowManagerInstance.OpenNewWindow(new UserProfileOwn(CurrentComment.UserComment));
      }
      else
      {
        AppContext.WindowManagerInstance.OpenNewWindow(new UserProfileOther(CurrentComment.UserComment));
      }
    }

    public void LoadComment()
    {
      try
      {
        CommentAuthor = CurrentComment.UserComment.Vorname + " " + CurrentComment.UserComment.Nachname;
        IsAuthorKnown = true;
      }
      catch (Exception)
      {
        CommentAuthor = "Unknown";
        IsAuthorKnown = false;
      }
    }

    private void Edit_Click(object sender, System.Windows.RoutedEventArgs e)
    {
    }

    private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
    {
      if (CheckCanEdit())
      {
        tboxComment.Visibility = Visibility.Visible;
        tbComment.Visibility = Visibility.Collapsed;
        tboxCommenttext.Visibility = Visibility.Visible;
        tbCommenttext.Visibility = Visibility.Collapsed;
        btnEdit.Content = "Save";
        btnEdit.Click -= Button_Click;
        btnEdit.Click += BtnEdit_Click;
      }
      else
      {
        MessageBox.Show("There was an Error");
      }
    }

    private bool CheckCanEdit()
    {
      if (CurrentComment.UserComment != null && CurrentComment.UserComment.ID_User == AppContext.LoggedInUser.ID_User)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    //SAVE
    private void BtnEdit_Click(object sender, RoutedEventArgs e)
    {
      HelpContext.Instance.Entry(CurrentComment).State = System.Data.Entity.EntityState.Modified;
      HelpContext.Instance.SaveChanges();
      Reset();
      WriteActivityEntry();
      WriteEMailNotification();
    }

    public void WriteEMailNotification()
    {
      if (AppContext.LoggedInUser.ID_User != CurrentComment.CommentArticle.Author.ID_User)
      {
        string Name = CurrentComment.CommentArticle.Author.Vorname + " " + CurrentComment.CommentArticle.Author.Nachname;
        string UserName = AppContext.LoggedInUser.Vorname + " " + AppContext.LoggedInUser.Nachname;
        string Message = string.Format(EMailTemplates.UserCommentedYourArticle, Name, UserName, CurrentComment.CommentArticle.ArticleTitle, CurrentComment.Comment);
        AppContext.MailHandlerInstance.SendPushEMail(Message, "Your Article got Commented", CurrentComment.CommentArticle.Author.EMail, EMailType.ArticleCommented);
      }
    }

    public void WriteActivityEntry()
    {
      Activity ac = new Activity()
      {
        //ActivityAction = LoadAction(),
        ActivityArticle = CurrentComment.CommentArticle,
        ActivityOn = DateTime.Now,
        ActivityUser = AppContext.LoggedInUser,
        ChangedPropertyName = "Kommentar",
        NewValue = CurrentComment.Comment,
        OldValue = OldCommentValue
      };
      HelpContext.Instance.Activities.Add(ac);
      HelpContext.Instance.SaveChanges();
    }

    //TODO Replace with WerteBereich
    //public ActivityAction LoadAction()
    //{
    //  var qry = from act in HelpContext.Instance.ActivityActions
    //            where act.ActionName == "Update"
    //            select act;
    //  return qry.FirstOrDefault();
    //}

    public void Reset()
    {
      tboxComment.Visibility = Visibility.Collapsed;
      tbComment.Visibility = Visibility.Visible;
      tboxCommenttext.Visibility = Visibility.Collapsed;
      tbCommenttext.Visibility = Visibility.Visible;
      btnEdit.Content = "Edit";
      btnEdit.Click += Button_Click;
      btnEdit.Click -= BtnEdit_Click;
    }
  }
}