using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Help
{
  public partial class ActivityListBoxItem : ListBoxItem
  {
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


        var qry = from uwa in HelpContext.Instance.UserWatchArticles
                  where uwa.WatchedArticle.ID_Article == CurrentActivity.ActivityArticle.ID_Article
                  where uwa.WatchedUser.ID_User == AppContext.LoggedInUser.ID_User
                  select uwa;
        UserWatchArticle a = qry.FirstOrDefault();
        if (a != null)
        {
          IsWatchedByCurrentUser = true;
          imgWatch.Source = new BitmapImage(new Uri("/Resources/Images/unwatched.png", UriKind.RelativeOrAbsolute));
        }
        else
        {
          IsWatchedByCurrentUser = false;
          imgWatch.Source = new BitmapImage(new Uri("/Resources/Images/watched.png", UriKind.RelativeOrAbsolute));
        }
      }
      else
      {

      }
    }

    public void LoadAction()
    {
      var qry = from act in HelpContext.Instance.ActivityActions
                where act.ActionName == "Update"
                select act;
      ActivityAction a = qry.FirstOrDefault();
      CurrentActivity.ActivityAction = a;
      switch (CurrentActivity.ActivityAction.ActionName)
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
      ActionString = CurrentActivity.ActivityAction.ActionName;
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
        var qry = from uwa in HelpContext.Instance.UserWatchArticles
                  where uwa.WatchedArticle.ID_Article == CurrentActivity.ActivityArticle.ID_Article
                  where uwa.WatchedUser.ID_User == AppContext.LoggedInUser.ID_User
                  select uwa;
        UserWatchArticle a = qry.FirstOrDefault();
        HelpContext.Instance.Entry(a).State = System.Data.Entity.EntityState.Deleted;
        HelpContext.Instance.SaveChanges();
      }
      CheckWatchList();
    }

    private void TextBlock_MouseUp(object sender, MouseButtonEventArgs e)
    {

    }
  }
}