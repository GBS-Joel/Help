using Help.EF;
using Help.Library;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Help
{
  public partial class ActivityListBoxItem : ListBoxItem
  {
    //TODO Move to Model
    public Activity CurrentActivity { get; set; }

    public string AuthorName { get; set; }

    public string ActionString { get; set; }

    public string ArticleTitle { get; set; }

    public string DateTimeAct { get; set; }

    public string NewValue { get; set; }

    public string OldValue { get; set; }

    public ActivityListBoxItem(Activity A)
    {
      CurrentActivity = A;
      LoadAuthor();
      InitializeComponent();
      DataContext = this;
      LoadAction();
      CheckWatchList();
    }

    public bool IsWatchedByCurrentUser { get; set; }

    public void CheckWatchList()
    {
      if (AppContext.IsLoggedIn)
      {
        int ID_Article, ID_User;
        ID_Article = CurrentActivity.ActivityArticle.ID_Article;
        ID_User = AppContext.LoggedInUser.ID_User;
        if (HelpService.GetService<UserWatchArticleService>().GetIfArticleIsWatchedFromUser(ID_Article, ID_User))
        {
          IsWatchedByCurrentUser = true;
          //imgWatch.Source = new BitmapImage(new Uri("pack://application:,,,/Help;Resources/Images/24x24/unwatched.png", UriKind.RelativeOrAbsolute));
          //  new BitmapImage(new Uri("Resources/Images/unwatched.png"));
        }
        else
        {
          IsWatchedByCurrentUser = false;
          //imgWatch.Source = new BitmapImage(new Uri("Resources/Images/watched.png", UriKind.RelativeOrAbsolute));
          //imgWatch.Source = new BitmapImage(new Uri("Resources/Images/24x24/watched.png", UriKind.RelativeOrAbsolute));
        }
      }
      else
      {
      }
    }

    public void LoadAction()
    {
      CurrentActivity.ActivityAction = AppContext.WerteBereichManagerInstance.GetWerteBereichByName("Activity.Action", "Update", WerteBereichValueDataType.text);
      switch (CurrentActivity.ActivityAction.Value)
      {
        case "Update":
          ActionText.Visibility = Visibility.Visible;
          NewValue = CurrentActivity.NewValue;
          OldValue = CurrentActivity.OldValue;
          break;

        default:
          ActionText.Visibility = Visibility.Collapsed;
          break;
      }
      ActionString = CurrentActivity.ActivityAction.Name;
    }

    public void LoadAuthor()
    {
      ActionString = "Aktualisierte ";
      DateTimeAct = Convert.ToString(DateTime.Now);
      AuthorName = CurrentActivity.ActivityUser.Vorname + " " + CurrentActivity.ActivityUser.Nachname;
      ArticleTitle = CurrentActivity.ActivityArticle.ArticleTitle;
    }

    private void tbWatch_MouseUp(object sender, MouseButtonEventArgs e)
    {
      if (!IsWatchedByCurrentUser)
      {
        UserWatchArticle uwa = new UserWatchArticle()
        {
          WatchedArticle = CurrentActivity.ActivityArticle,
          WatchedTime = DateTime.Now,
          WatchedUser = AppContext.LoggedInUser
        };
        HelpContext.Instance.UserWatchArticles.Add(uwa);
        HelpContext.Instance.SaveChanges();
      }
      else
      {
        int ID_Article, ID_User;
        ID_Article = CurrentActivity.ActivityArticle.ID_Article;
        ID_User = AppContext.LoggedInUser.ID_User;
        var a = HelpService.GetService<UserWatchArticleService>().GetUserWatchedArticle(ID_Article, ID_User);
        HelpService.GetService<UserWatchArticleService>().DeleteEntity(a);
      }
      CheckWatchList();
    }

    private void TextBlock_MouseUp(object sender, MouseButtonEventArgs e)
    {
    }
  }
}