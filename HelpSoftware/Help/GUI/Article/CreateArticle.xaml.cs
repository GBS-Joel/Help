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
using Markdig.Wpf;
using XamlReader = System.Windows.Markup.XamlReader;
using Markdig;
using System.IO;
using System.Xaml;
using System.Reflection;

namespace Help
{
  public partial class CreateArticle : MetroWindow
  {
    public CreateArticle()
    {
      InitializeComponent();
    }

    private void btnPreview_Click(object sender, RoutedEventArgs e)
    {
      string a = tbArticleText.Text;
      string b = a.Replace("\r\n", Environment.NewLine + "" + Environment.NewLine);

      Article art = new Article()
      {
        ArticleText = b
      };

      ArticlePreview prev = new ArticlePreview(art);
      prev.Show();
    }

    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
      string a = tbArticleText.Text;
      string b = a.Replace("\r\n", Environment.NewLine + "" + Environment.NewLine);
      Article art = new Article()
      {
        ArticleText = b,
        Created = DateTime.Now,
        Stars = 0,
        Views = 0,
        ArticleTitle = tbTitle.Text,
        LastModifiedDate = DateTime.Now,
        Favorits = 0
      };
      HelpContext.Instance.Articles.Add(art);
      HelpContext.Instance.SaveChanges();
    }

    private void btnWrite_Click(object sender, RoutedEventArgs e)
    {
      string a = tbArticleText.Text;
      string b = a.Replace("\r\n", Environment.NewLine + "" + Environment.NewLine);

      Article art = new Article()
      {
        ArticleText = b
      };

      WriteArticleText prev = new WriteArticleText(art);
      prev.Show();
    }
  }
}