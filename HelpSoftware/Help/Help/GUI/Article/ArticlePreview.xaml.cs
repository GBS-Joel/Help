using Help.EF;
using Help.Library;
using Markdig;
using Markdig.Wpf;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Xaml;
using XamlReader = System.Windows.Markup.XamlReader;

namespace Help
{
  public partial class ArticlePreview : HelpUserControl
  {
    public Article CurrentArticle { get; set; }

    public ArticlePreview(Article Art)
    {
      InitializeComponent();
      CurrentArticle = Art;
      Loaded += ArticlePreview_Loaded;
    }

    private static MarkdownPipeline BuildPipeline()
    {
      return new MarkdownPipelineBuilder()
          .UseSupportedExtensions()
          .Build();
    }

    private void ArticlePreview_Loaded(object sender, RoutedEventArgs e)
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
  }
}