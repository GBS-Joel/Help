using Help.EF;
using Help.Library;
using Markdig;
using Markdig.Wpf;
using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Xaml;
using XamlReader = System.Windows.Markup.XamlReader;

namespace Help
{
  public partial class ArticleDetail : HelpUserControl
  {
    public Article CurrentArticle { get; set; }

    public ArticleDetail(Article Art)
    {
      InitializeComponent();
      Loaded += ArticleDetail_Loaded;
      CurrentArticle = Art;
      TabComments.Content = new ArticleComments(Art);
      WriteArticleHistroy();
    }

    public void WriteArticleHistroy()
    {
      if (AppContext.IsLoggedIn)
      {
        ArticleViewHistory history = new ArticleViewHistory()
        {
          Article = CurrentArticle,
          User = AppContext.LoggedInUser,
          ViewTime = DateTime.Now
        };
        HelpContext.Instance.ArticleViewHistories.Add(history);
      }
      else
      {
        ArticleViewHistory history = new ArticleViewHistory()
        {
          Article = CurrentArticle,
          User = null,
          ViewTime = DateTime.Now
        };
        HelpContext.Instance.ArticleViewHistories.Add(history);
      }
      HelpContext.Instance.SaveChanges();
    }

    private void ArticleDetail_Loaded(object sender, RoutedEventArgs e)
    {
      var markdown = CurrentArticle.ArticleText;
      var xaml = Markdig.Wpf.Markdown.ToXaml(markdown, BuildPipeline());
      using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(xaml)))
      {
        var reader = new XamlXmlReader(stream, new MyXamlSchemaContext());
        var document = XamlReader.Load(reader) as FlowDocument;
        if (document != null)
        {
          Viewer.Document = document;
        }
      }
    }

    private static MarkdownPipeline BuildPipeline()
    {
      return new MarkdownPipelineBuilder()
          .UseSupportedExtensions()
          .Build();
    }
  }
}