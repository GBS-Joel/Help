using Help.EF;
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
  public partial class DiscoverArticle : UserControl
  {
    public Article CurrentArticle { get; set; }

    public string Title { get; set; }

    public string Preview { get; set; }

    public DiscoverArticle(Article Article)
    {
      InitializeComponent();
      CurrentArticle = Article;
      Title = CurrentArticle.ArticleTitle;
      Preview = CurrentArticle.ArticlePreview + "...";
      DataContext = this;
    }

    private void Label_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
    {
      MessageBox.Show(CurrentArticle.ArticleTitle);
    }
  }
}