using Help.EF;
using Help.Library;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Help
{
  public partial class ArticleSearchResult : HelpUserControl
  {
    public List<Article> Result { get; set; }

    public override IModel Model { get; set; }

    public ArticleSearchResult(List<Article> searchresult)
    {
      InitializeComponent();
      Loaded += ArticleSearchResult_Loaded;
      Result = searchresult;
    }

    private void ArticleSearchResult_Loaded(object sender, RoutedEventArgs e)
    {
      List<ArticleListBoxItem> BoxItems = new List<ArticleListBoxItem>();
      foreach (var item in Result)
      {
        ArticleListBoxItem boxitem = new ArticleListBoxItem(item);
        boxitem.Width = lbResult.Width;
        BoxItems.Add(boxitem);
      }
      lbResult.ItemsSource = BoxItems;
    }

    private void btnPropose_Click(object sender, RoutedEventArgs e)
    {
      AppContext.WindowManagerInstance.OpenNewWindow(new ProposeArticle());
    }

    private void btnPush_Click(object sender, RoutedEventArgs e)
    {
      AppContext.WindowManagerInstance.OpenNewWindow(new PushUser());
    }

    private void lbResult_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
      Article a = (Article)((ArticleListBoxItem)lbResult.SelectedItem).Article;
      AppContext.WindowManagerInstance.OpenNewWindow(new ArticleDetail(a));
    }

    public override void DisplayData()
    {
    }

    public override void HandleInitLoad()
    {
    }

    public override void PerformAfterLogin()
    {
      throw new NotImplementedException();
    }

    public override void UdpateAfterDatabaseInitialized()
    {
      throw new NotImplementedException();
    }

    public override void UpdateOnLogin()
    {
      throw new NotImplementedException();
    }

    public override void UpdateOnLogOut()
    {
      throw new NotImplementedException();
    }
  }
}