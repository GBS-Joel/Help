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
  public partial class ArticleComments : UserControl
  {
    public Article CurrentArticle { get; set; }

    List<ArticleComment> Comments { get; set; }

    public ArticleComments(Article Art)
    {
      InitializeComponent();
      CurrentArticle = Art;
      LoadComments();
      DisplayComments();
    }

    public void DisplayComments()
    {
      List<CommentListBoxItem> boxcomments = new List<CommentListBoxItem>();
      foreach (ArticleComment item in Comments)
      {
        CommentListBoxItem boxitem = new CommentListBoxItem(item);
        boxitem.Width = lboxTop.Width;
        boxcomments.Add(boxitem);
      }
      lboxTop.ItemsSource = boxcomments;
    }

    public void LoadComments()
    {
      var qry = from ac in HelpContext.Instance.ArticleComments
                where ac.CommentArticle.ID_Article == CurrentArticle.ID_Article
                select ac;
      Comments = qry.ToList();
    }

    private void test_Click(object sender, RoutedEventArgs e)
    {

    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {

    }
  }
}