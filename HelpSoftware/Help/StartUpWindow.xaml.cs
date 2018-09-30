using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Collections.Generic;

namespace Help
{
  public partial class StartUpWindow : UserControl
  {
    public List<User> User { get; set; }

    public List<Article> NewestArticles { get; set; }

    public StartUpWindow()
    {
      InitializeComponent();
      if (!AppContext.IsLoggedIn)
      {
        mtiRecView.Visibility = Visibility.Collapsed;
        exAdvancedSearch.IsEnabled = false;
        exAdvancedSearch.Opacity = 1;
      }
      lboxTop.MouseDoubleClick += LboxTop_MouseDoubleClick;
      DoStartUp();

    }

    public void PerformAfterLogin()
    {
      mtiRecView.Visibility = Visibility.Visible;
      exAdvancedSearch.IsEnabled = true;
    }

    private void LboxTop_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
      Article a = ((ArticleListBoxItem)((ListBox)sender).SelectedItem).Article;
      MessageBox.Show(a.ArticleTitle);
    }

    public void DoStartUp()
    {
      if (AppContext.IsLoggedIn)
      {
        LoadNewestArticles();
      }
      else
      {
        LoadNewestArticles();
        if (AppContext.IsLoggedIn)
        {
          LoadRecentlyViewed();
        }
      }
    }

    public void LoadRecentlyViewed()
    {
      var qry = from art in HelpContext.Instance.Articles
                join arthist in HelpContext.Instance.ArticleViewHistories
                on art.ID_Article equals arthist.Article.ID_Article
                where arthist.User.ID_User == AppContext.LoggedInUser.ID_User
                orderby arthist.ViewTime descending
                select art;
      List<Article> Arts = qry.ToList();
      List<ArticleListBoxItem> BoxItems = new List<ArticleListBoxItem>();
      foreach (Article item in Arts)
      {
        ArticleListBoxItem boxitem = new ArticleListBoxItem(item);
        boxitem.Width = lboxRecView.Width;
        BoxItems.Add(boxitem);
      }
      lboxRecView.ItemsSource = BoxItems;
    }

    public void LoadNewestArticles()
    {
      var qry = (from art in HelpContext.Instance.Articles
                 orderby art.Created descending
                 join us in HelpContext.Instance.Users on art.Author.ID_User equals us.ID_User
                 where art.Public == true
                 select art).Take(100);

      List<Article> articles = new List<Article>();
      NewestArticles = articles;
      articles = qry.ToList();
      List<ArticleListBoxItem> items = new List<ArticleListBoxItem>();
      foreach (Article item in articles)
      {
        ArticleListBoxItem boxitem = new ArticleListBoxItem(item, false);
        boxitem.MaxWidth = lboxTop.Width;
        items.Add(boxitem);
      }
      lbboxNew.ItemsSource = items;
    }

    public void LoadUsers()
    {
      var qry = from users in HelpContext.Instance.Users
                where users.IsActive == true
                select users;
      User = qry.ToList();
    }

    private void btnCreateNewEntry_Click(object sender, RoutedEventArgs e)
    {
      if (AppContext.IsLoggedIn)
      {
        CreateArticle window = new CreateArticle();
        window.Show();
      }
      else
      {
        MessageBox.Show("You Are not logged IN");
      }
    }

    private void advancdedSearch_Click(object sender, RoutedEventArgs e)
    {
      PushUser user = new PushUser();
      user.Show();

      //var qry = from art in HelpContext.Instance.Articles
      //          select art;
      //Article a = qry.FirstOrDefault();

      //var qry1 = from t in HelpContext.Instance.Tags
      //           select t;

      //Tag ta = qry1.FirstOrDefault();

      //ArticleTag at = new ArticleTag();
      //at.Article = a;
      //at.Tag = ta;
      //at.AssingTime = DateTime.Now;
      //at.User = null;
      //HelpContext.Instance.ArticleTags.Add(at);
      //HelpContext.Instance.SaveChanges();
    }

    private void btnCreateTags_Click(object sender, RoutedEventArgs e)
    {
      //ShowTag tag = new ShowTag();
      //tag.Show();

      Topic t = new Topic()
      {
        Name = "Test",
        Description = "This is A Test",
        LastModified = DateTime.Now,
      };
      Topic t1 = new Topic()
      {
        Name = "Test",
        Description = "This is A Test",
        LastModified = DateTime.Now,
      };
      Topic t2 = new Topic()
      {
        Name = "Test",
        Description = "This is A Test",
        LastModified = DateTime.Now,
      };
      Topic t3 = new Topic()
      {
        Name = "Test",
        Description = "This is A Test",
        LastModified = DateTime.Now,
      };




      //HelpContext.Instance.Topics.Add(t);
      //HelpContext.Instance.Topics.Add(t1);
      //HelpContext.Instance.Topics.Add(t2);
      //HelpContext.Instance.Topics.Add(t3);

      HelpContext.Instance.SaveChanges();

      ShowTopic o = new ShowTopic();
      o.Show();
    }

    private void btnSearch_Click(object sender, RoutedEventArgs e)
    {
      WriteHistoryEntry();
      string searchqry = tbSearch.Text;
      PerformSearch(searchqry);
    }

    public void PerformSearch(string searchtext)
    {
      if (searchtext != "")
      {
        var qry = from art in HelpContext.Instance.Articles
                  where art.ArticleTitle.Contains(searchtext)
                  select art;
        if (qry.Count() < 10)
        {
          var qryres = from art in HelpContext.Instance.Articles
                       where art.ArticleTitle.Contains(searchtext)
                       || art.ArticlePreview.Contains(searchtext)
                       select art;
          List<Article> res = qryres.ToList();
          if (res.Count() != 0)
          {
            ArticleSearchResult result = new ArticleSearchResult(res.ToList());
            result.Show();
          }
        }
        else
        {
          List<Article> res = qry.ToList();
          if (res.Count() != 0)
          {
            ArticleSearchResult result = new ArticleSearchResult(res.ToList());
            result.Show();
          }
        }
      }
    }

    public void WriteHistoryEntry()
    {
      if (AppContext.IsLoggedIn && tbSearch.Text != null)
      {
        SearchHistory h = new SearchHistory()
        {
          SearchText = tbSearch.Text,
          SearchedUser = AppContext.LoggedInUser,
          SearchTime = DateTime.Now
        };
        HelpContext.Instance.SearchHistories.Add(h);
        HelpContext.Instance.SaveChanges();
      }
    }

    private void Tile_Click(object sender, RoutedEventArgs e)
    {
      Tag t = new Help.Tag()
      {
        TagName = "Test Tag",
        ColorString = "#FFFFFF",
        Created = DateTime.Today,
        TagDescription = "This ist a descritption for the tag"
      };
      HelpContext.Instance.Tags.Add(t);
      HelpContext.Instance.SaveChanges();
    }

    private void lboxTop_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
    {
      var a = (ArticleListBoxItem)lbboxNew.SelectedItem;
      Article art = a.Article;
      ArticleDetail detail = new ArticleDetail(art);
      detail.Show();
    }
  }
}