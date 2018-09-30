using Help.EF;
using Markdig;
using Markdig.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Xaml;
using System.Windows.Input;
using XamlReader = System.Windows.Markup.XamlReader;
using System.Windows.Media;
using MahApps.Metro.Controls;
using MahApps.Metro;
using MahApps.Metro.SimpleChildWindow;
using System.Xml;
using System.Windows.Shapes;

namespace Help.Light
{
  public partial class MainWindow : MetroWindow
  {
    public LightSetting CurrentSetting { get; set; }

    public ArticleFile CurrentArticle { get; set; }

    public MainWindow(ArticleFile file)
    {
      HelpContext.InitInstance();
      InitializeComponent();
      TryLoadSetting();
      CurrentArticle = file;
      Loaded += MainWindow_Loaded;
      Title = "Article: " + file.Title;
    }

    public void TryLoadSetting()
    {
      string filepath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
      string conpath = System.IO.Path.Combine(filepath, @"Help\Light_Setting.txt");
      if (File.Exists(conpath))
      {
        XmlDocument doc = new XmlDocument();
        doc.Load(conpath);
        string DarkTheme = "";
        string RandomAppTheme = "";
        string AppTheme = "";
        foreach (XmlNode node in doc.DocumentElement.ChildNodes)
        {
          switch (node.Name)
          {
            case "DarkTheme":
              DarkTheme = node.InnerText;
              break;
            case "RandomAppTheme":
              RandomAppTheme = node.InnerText;
              break;
            case "AppTheme":
              AppTheme = node.InnerText;
              break;
          }
        }
        ApplicationThemes s = ApplicationThemes.Amber;
        try
        {
          s = (ApplicationThemes)Enum.Parse(typeof(ApplicationThemes), AppTheme);
        }
        catch (Exception)
        {
          s = (ApplicationThemes)Enum.Parse(typeof(ApplicationThemes), GetRandomAppTheme());
        }
        CurrentSetting = new LightSetting()
        {
          IsDarkThemeEnabled = DarkTheme == "1",
          Theme = s,
          RandomAppThemeEnabled = RandomAppTheme == "1"
        };
      }
      else
      {
        CurrentSetting = new LightSetting() { IsDarkThemeEnabled = false, RandomAppThemeEnabled = true, Theme = ApplicationThemes.Amber };
      }
    }

    public string GetRandomAppTheme()
    {
      Array values = Enum.GetValues(typeof(ApplicationThemes));
      Random random = new Random();
      ApplicationThemes randomBar = (ApplicationThemes)values.GetValue(random.Next(values.Length));
      return randomBar.ToString();
    }

    private MarkdownPipeline BuildPipeline()
    {
      return new MarkdownPipelineBuilder()
          .UseSupportedExtensions()
          .Build();
    }

    public void LoadArt()
    {
      var markdown = CurrentArticle.Text;
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

    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
      LoadArt();
      ApplySetting(CurrentSetting);
      Focus();
    }

    protected override void OnContentRendered(EventArgs e)
    {
      base.OnContentRendered(e);
      SubscribeToAllHyperlinks();
    }

    public void SubscribeToAllHyperlinks()
    {
      FlowDocument flowDocument = Viewer.Document;
      foreach (var link in GetVisuals(flowDocument).OfType<Hyperlink>())
      {
        link.MouseDown += Link_MouseDown;
        link.MouseEnter += Link_MouseEnter;
        link.MouseLeave += Link_MouseLeave;
        if (CurrentSetting.IsDarkThemeEnabled)
          link.Foreground = Brushes.DeepSkyBlue;
        else
          link.Foreground = Brushes.Blue;
        link.RequestNavigate += link_RequestNavigate;
      }

      if (flowDocument != null)
      {
        foreach (var item in GetVisuals(flowDocument).OfType<Run>())
        {
          if (CurrentSetting.IsDarkThemeEnabled)
            item.Foreground = Brushes.White;
          else
            item.Foreground = Brushes.Black;
        }

        foreach (var item in GetVisuals(flowDocument).OfType<Line>())
        {
          if (CurrentSetting.IsDarkThemeEnabled)
            item.Stroke = Brushes.White;
          else
            item.Stroke = Brushes.Black;
        }

      }
    }

    private void Link_MouseLeave(object sender, MouseEventArgs e)
    {
      if (this.Cursor != Cursors.Wait)
        Mouse.OverrideCursor = Cursors.Arrow;
    }

    private void Link_MouseEnter(object sender, MouseEventArgs e)
    {
      if (Cursor != Cursors.Wait)
        Mouse.OverrideCursor = Cursors.Hand;
    }

    private void Link_MouseDown(object sender, MouseButtonEventArgs e)
    {
      try
      {
        Process.Start(new ProcessStartInfo(((Hyperlink)sender).CommandParameter.ToString()));
      }
      catch (Exception)
      {
        MessageBox.Show("Could not Open Link " + ((Hyperlink)sender).CommandParameter.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
      }
    }

    public static IEnumerable<DependencyObject> GetVisuals(DependencyObject root)
    {
      foreach (var child in LogicalTreeHelper.GetChildren(root).OfType<DependencyObject>())
      {
        yield return child;
        foreach (var descendants in GetVisuals(child))
          yield return descendants;
      }
    }

    void link_RequestNavigate(object sender, RequestNavigateEventArgs e)
    {
      Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
      e.Handled = true;
    }

    public void ApplySetting(LightSetting setting)
    {
      CurrentSetting = setting;
      if (setting.IsDarkThemeEnabled && setting.RandomAppThemeEnabled)
      {
        ThemeManager.ChangeAppStyle(Application.Current,
                            ThemeManager.GetAccent(GetRandomAppTheme()),
                            ThemeManager.GetAppTheme("BaseDark"));
      }
      else if (!setting.IsDarkThemeEnabled && setting.RandomAppThemeEnabled)
      {
        ThemeManager.ChangeAppStyle(Application.Current,
                            ThemeManager.GetAccent(GetRandomAppTheme()),
                            ThemeManager.GetAppTheme("BaseLight"));
      }
      else if (setting.IsDarkThemeEnabled && (!setting.RandomAppThemeEnabled))
      {
        ThemeManager.ChangeAppStyle(Application.Current,
                            ThemeManager.GetAccent(setting.Theme.ToString()),
                            ThemeManager.GetAppTheme("BaseDark"));
      }
      else if (!setting.IsDarkThemeEnabled && !setting.RandomAppThemeEnabled)
      {
        ThemeManager.ChangeAppStyle(Application.Current,
                            ThemeManager.GetAccent(setting.Theme.ToString()),
                            ThemeManager.GetAppTheme("BaseLight"));
      }
      else
      {
        ThemeManager.ChangeAppStyle(Application.Current,
                            ThemeManager.GetAccent(GetRandomAppTheme()),
                            ThemeManager.GetAppTheme("BaseLight"));
      }
      LoadArt();
    }

    private async void btnSettings_Click(object sender, RoutedEventArgs e)
    {
      await this.ShowChildWindowAsync(new Settings(this, CurrentSetting) { IsModal = true });
      System.Windows.Forms.Application.Restart();
      System.Windows.Application.Current.Shutdown();
    }
  }
}