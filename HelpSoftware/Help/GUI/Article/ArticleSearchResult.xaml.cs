using MahApps.Metro.Controls;
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
using System.Windows.Shapes;

namespace Help
{
  public partial class ArticleSearchResult : MetroWindow
  {
    public List<Article> Result { get; set; }

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
      ProposeArticle art = new ProposeArticle();
      art.Show();
    }

    private void btnPush_Click(object sender, RoutedEventArgs e)
    {
      new PushUser().Show();
    }

    private void lbResult_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
      Article a = (Article)((ArticleListBoxItem)lbResult.SelectedItem).Article;
      ArticleDetail detail = new ArticleDetail(a);
      detail.Show();
    }
  }
}