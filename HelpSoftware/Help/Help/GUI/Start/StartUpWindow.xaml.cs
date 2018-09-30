using Help.EF;
using Help.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Help
{
  public partial class StartUpWindow : HelpUserControl
  {
    public List<User> User { get; set; }

    public List<Article> NewestArticles { get; set; }

    public override IModel Model { get; set; }

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
      LoadDashBoard();
    }

    public void LoadDashBoard()
    {
      if (AppContext.IsLoggedIn)
      {
        var qry = from d in HelpContext.Instance.DashBoardUsers
                  where d.User.ID_User == AppContext.LoggedInUser.ID_User
                  select d;
      }
    }

    private void LboxTop_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
      Article a = ((ArticleListBoxItem)((ListBox)sender).SelectedItem).Article;
      MessageBox.Show(a.ArticleTitle);
    }

    public void DoStartUp()
    {
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
        AppContext.WindowManagerInstance.OpenNewWindow(new CreateArticle());
      }
      else
      {
        MessageBox.Show("You Are not logged IN");
      }
    }

    private void advancdedSearch_Click(object sender, RoutedEventArgs e)
    {
      AppContext.WindowManagerInstance.OpenNewWindow(new PushUser());
    }

    private void btnCreateTags_Click(object sender, RoutedEventArgs e)
    {
      AppContext.WindowManagerInstance.OpenNewWindow(new CreateBooklet());
      HelpContext.Instance.SaveChanges();
      AppContext.WindowManagerInstance.OpenNewWindow(new ShowTopic());
    }

    private void btnSearch_Click(object sender, RoutedEventArgs e)
    {
      WriteHistoryEntry();
      string searchqry = tbSearch.Text;
      PerformSearch(searchqry);
    }

    public void PerformSearch(string searchtext)
    {
      var res = AppContext.SearchHelperInstance.PerformSearch(searchtext);
      if (res.Any())
      {
        AppContext.WindowManagerInstance.OpenNewWindow(new ArticleSearchResult(res));
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
      Browser b = new Browser();
      b.Show();
    }

    private void lboxTop_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
    {
      var a = (ArticleListBoxItem)lbboxNew.SelectedItem;
      Article art = a.Article;
      AppContext.WindowManagerInstance.OpenNewWindow(new ArticleDetail(art));
    }

    private void ScrolltoBottom_Click(object sender, RoutedEventArgs e)
    {
      lbboxNew.SelectedItem = lbboxNew.Items[lbboxNew.Items.Count - 1];
      lbboxNew.ScrollIntoView(lbboxNew.SelectedItem);
    }

    public override void DisplayData()
    {
    }

    public override void HandleInitLoad()
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

    public override void PerformAfterLogin()
    {
      mtiRecView.Visibility = Visibility.Visible;
      exAdvancedSearch.IsEnabled = true;
    }

    public override void UdpateAfterDatabaseInitialized()
    {
    }

    //GUI Update
    public override void UpdateOnLogin()
    {
    }

    public override void UpdateOnLogOut()
    {
    }
  }
}