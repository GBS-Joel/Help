using Help.EF;
using Help.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Help
{
  public partial class ArticleListBoxItem : ListBoxItem, INotifyPropertyChanged
  {
    public Article Article { get; set; }

    public string TagString { get; set; }

    public string Author { get; set; }

    public bool IsAuthorKnown { get; set; }

    public bool HasUserFavoritedArticel { get; set; }

    public bool HasUserLikedArticel { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

    public bool IsReadOnlyArticle { get; set; }

    private ArticleListBoxItem()
    {
    }

    public ArticleListBoxItem(Article Article) : this(Article, false)
    {
    }

    public ArticleListBoxItem(Article Article, bool IsReadOnlyArticle)
    {
      InitializeComponent();
      this.Article = Article;
      this.IsReadOnlyArticle = IsReadOnlyArticle;
      DataContext = this;
      LoadTags();
      LoadAuthor();
      PerformStartUp();
    }

    public void PerformStartUp()
    {
      if (!IsReadOnlyArticle && AppContext.IsLoggedIn)
      {
        imgHeart.MouseEnter += Image_MouseEnter;
        imgHeart.MouseLeave += Image_MouseLeave;
        imgLike.MouseEnter += Image_MouseEnter;
        imgLike.MouseEnter += Image_MouseLeave;
      }      
    }

    private void CheckStar()
    {
      if (AppContext.IsLoggedIn)
      {
        int ID_User, ID_Article;
        ID_User = AppContext.LoggedInUser.ID_User;
        ID_Article = Article.ID_Article;
        if (HelpService.GetService<UserLikedArticelService>().CheckIfUserHasLikedArticle(ID_User, ID_Article))
        {
          HasUserLikedArticel = true;
          imgLike.Source = new BitmapImage(new Uri("../Resources/Images/24x24/star_checked.png", UriKind.RelativeOrAbsolute));
        }
        else
        {
          HasUserLikedArticel = false;
          imgLike.Source = new BitmapImage(new Uri("../Resources/Images/24x24/star_unchecked.png", UriKind.RelativeOrAbsolute));
        }
      }
    }

    public void CheckHeart()
    {
      if (AppContext.IsLoggedIn)
      {
        int ID_Article, ID_User;
        ID_Article = Article.ID_Article;
        ID_User = AppContext.LoggedInUser.ID_User;
        if (HelpService.GetService<UserLikedArticelService>().CheckIfUserHasLikedArticle(ID_Article, ID_User))
        {
          imgHeart.Source = new BitmapImage(new Uri("../Resources/Images/24x24/heart_checked.png", UriKind.RelativeOrAbsolute));
          HasUserFavoritedArticel = true;
        }
        else
        {
          imgHeart.Source = new BitmapImage(new Uri("../Resources/Images/24x24/heart_unchecked.png", UriKind.RelativeOrAbsolute));
          HasUserFavoritedArticel = false;
        }
      }
    }

    public void LoadAuthor()
    {
      if (Article.Author != null)
      {
        if (AppContext.IsLoggedIn)
        {
          IsAuthorKnown = true;
          Author = Article.Author.Vorname + " " + Article.Author.Nachname;
        }
        else
        {
          IsAuthorKnown = true;
          Author = Article.Author.Nick;
        }
      }
      else
      {
        Author = "Unknown Author";
        IsAuthorKnown = false;
      }
    }

    public void LoadTags()
    {
      if (Article.Tags != null)
      {
        var qry = from at in HelpContext.Instance.ArticleTags
                  where at.Article.ID_Article == Article.ID_Article
                  join t in HelpContext.Instance.Tags on at.Tag.ID_Tag equals t.ID_Tag
                  select at;

        List<ArticleTag> tags = qry.ToList();
        if (tags == null)
        {
          AppContext.Logger.Warn("There Are no Tags found on Article", "ID_Article: " + Article.ID_Article);
          TagString = "There are no Tags";
        }
        else
        {
          foreach (ArticleTag item in tags)
          {
            TagString += item.Tag.TagName + ", ";
          }
        }
      }
      else
      {
        TagString = "There are no Tags";
      }
    }

    private void Image_MouseEnter(object sender, MouseEventArgs e)
    {
      Image img = ((Image)sender);
      img.Height = img.ActualHeight * 1.2;
      img.Width = img.ActualWidth * 1.2;
    }

    private void Image_MouseLeave(object sender, MouseEventArgs e)
    {
      Image img = ((Image)sender);
      img.Height /= 1.2;
      img.Width /= 1.2;
    }

    private void ListBoxItem_Loaded(object sender, RoutedEventArgs e)
    {
      CheckHeart();
      CheckStar();
    }

    private void imgHeart_MouseUp(object sender, MouseButtonEventArgs e)
    {
      if (AppContext.IsLoggedIn)
      {
        if (!IsReadOnlyArticle)
        {
          if (HasUserFavoritedArticel)
          {
            int ID_User, ID_Article;
            ID_User = AppContext.LoggedInUser.ID_User;
            ID_Article = Article.ID_Article;
            UserFavedArticles a = HelpService.GetService<UserFavedArticleService>().GetUserFavedArticle(ID_Article, ID_User);
            Article.Favorits--;
            HelpService.GetService<UserFavedArticleService>().DeleteEntity(a);
            UpdateArticle("Article.Favorits");
            CheckHeart();
          }
          else
          {
            HasUserFavoritedArticel = false;
            UserFavedArticles a = new UserFavedArticles()
            {
              FavedUser = AppContext.LoggedInUser,
              FavedArticle = Article,
              FavedTime = DateTime.Now
            };
            HelpContext.Instance.UserFavedArticles.Add(a);
            Article.Favorits++;
            HelpContext.Instance.SaveChanges();
            HelpContext.Instance.Entry(a).Reload();
            CheckHeart();
            UpdateArticle("Article.Favorits");
            SendNotificationMailFavorited(a);
          }
        }
      }
    }

    public void SendNotificationMailFavorited(UserFavedArticles a)
    {
      var qry = from userse in HelpContext.Instance.UserSettings
                where userse.User.ID_User == a.FavedUser.ID_User
                where userse.Setting.SettingName == "SendNotfificationOnArticleFavorited"
                select userse;
      if (qry.FirstOrDefault() != null)
      {
        UserSetting setting = qry.FirstOrDefault();
        if (setting.UserValue == "1")
        {
          string FullNameAuthor = a.FavedArticle.Author.Vorname + " " + a.FavedArticle.Author.Nachname;
          string LikedUserName = a.FavedUser.Vorname + " " + a.FavedUser.Nachname;
          if (FullNameAuthor != LikedUserName)
          {
            string mailmessage = String.Format(EMailTemplates.UserFavoritedArticle, FullNameAuthor, LikedUserName, a.FavedArticle.ArticleTitle, a.FavedArticle.ArticlePreview);
            AppContext.MailHandlerInstance.SendPushEMail(mailmessage, "Your Article Got Favorited", a.FavedArticle.Author.EMail, EMailType.ArticleFavorited);
          }
        }
      }
    }

    private void imgLike_MouseUp(object sender, MouseButtonEventArgs e)
    {
      if (AppContext.IsLoggedIn)
      {
        if (!IsReadOnlyArticle)
        {
          if (HasUserLikedArticel)
          {
            var qry = from use in HelpContext.Instance.UserLikedArticels
                      where use.LikedUser.ID_User == AppContext.LoggedInUser.ID_User
                      where use.LikedArticel.ID_Article == Article.ID_Article
                      select use;
            UserLikedArticel u = qry.FirstOrDefault();
            HelpContext.Instance.Entry(u).State = System.Data.Entity.EntityState.Deleted;
            Article.Stars--;
            HelpContext.Instance.SaveChanges();
            HasUserLikedArticel = false;
            CheckStar();
            UpdateArticle("Article.Stars");
          }
          else
          {
            HasUserLikedArticel = true;
            UserLikedArticel a = new UserLikedArticel()
            {
              LikedArticel = Article,
              LikedUser = AppContext.LoggedInUser,
              LikedTime = DateTime.Now
            };
            HelpContext.Instance.UserLikedArticels.Add(a);
            Article.Stars++;
            HelpContext.Instance.SaveChanges();
            CheckStar();
            UpdateArticle("Article.Stars");
            SendNotificationMailLiked(a);
          }
        }
      }
    }

    public void SendNotificationMailLiked(UserLikedArticel a)
    {
      string name = "SendNotfificationOnArticleFavorited";
      UserSetting setting = AppContext.HelpSettingsHandler.UserSettingsHandler.GetUserSettingFromName(name);
      if (setting != null)
      {
        if (setting.UserValue == "1")
        {
          string FullNameAuthor = a.LikedArticel.Author.Vorname + " " + a.LikedArticel.Author.Nachname;
          string LikedUserName = a.LikedUser.Vorname + " " + a.LikedUser.Nachname;
          if (FullNameAuthor != LikedUserName)
          {
            string mailmessage = String.Format(EMailTemplates.UserLikedArticle, FullNameAuthor, LikedUserName, a.LikedArticel.ArticleTitle, a.LikedArticel.ArticlePreview);
            AppContext.MailHandlerInstance.SendPushEMail(mailmessage, "Your Article Got Liked", a.LikedArticel.Author.EMail, EMailType.ArticleLiked);
          }
        }
      }
    }

    public void UpdateArticle(string name)
    {
      PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
      lblStars.Content = Article.Stars;
      lblFavorits.Content = Article.Favorits;
    }

    //TODO
    private void tbAuthor_MouseUp(object sender, MouseButtonEventArgs e)
    {
      if (IsAuthorKnown)
      {
        if (AppContext.LoggedInUser != null)
        {
          if (Article.Author.ID_User == AppContext.LoggedInUser.ID_User)
          {
            AppContext.WindowManagerInstance.OpenNewWindow(new UserProfileOwn(Article.Author));
          }
          else
          {
            UserProfileOther o = new UserProfileOther(Article.Author);
          }
        }
        else
        {
          AppContext.WindowManagerInstance.OpenNewWindow(new UserProfileOther(Article.Author));
        }
      }
      else
      {
        AppContext.WindowManagerInstance.OpenNewWindow(new UserProfileOther(Article.Author));
      }
    }

    private void MenuWatch_Click(object sender, RoutedEventArgs e)
    {
    }
  }
}