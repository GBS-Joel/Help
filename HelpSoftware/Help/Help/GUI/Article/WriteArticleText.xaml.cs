using Help.EF;
using Help.Library;
using System.Windows;

namespace Help
{
  public partial class WriteArticleText : HelpUserControl
  {
    public Article CurrentArticle { get; set; }

    public WriteArticleText(Article a)
    {
      InitializeComponent();
      CurrentArticle = a;
      tbTitle.Text = a.ArticleTitle;
    }

    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
    }
  }
}