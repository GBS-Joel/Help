using Help.EF;
using Help.Library;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Help.Stats
{
  /// <summary>
  /// Interaktionslogik für TagsAndCountArticle.xaml
  /// </summary>
  public partial class TagsAndCountArticle : Window
  {
    public TagsAndCountArticle()
    {
      InitializeComponent();
      var ServiceClient = new Help.Stats.TagService.TagWCFServiceClient();
      string name = ServiceClient.GetAll();
      var r = (List<Tag>)JSONSerializer.JSONToObject(name, typeof(List<Tag>));

      var ArticleServiceClient = new ArticleService.ArticleWCFServiceClient();
      string arts = ArticleServiceClient.GetAll();
      var a = (List<Article>)JSONSerializer.JSONToObject(arts, typeof(List<Article>));

      //Get The Articles Per Year
      var group = a.GroupBy(u => u.Created.Value.Year).Select(grp => grp.ToList()).ToList();
      SeriesCollection = new SeriesCollection();
      foreach (var item in group)
      {
        var res = item.GroupBy(x => x.Tags).Select(grp => grp.ToList()).ToList();
        List<double> Counts = new List<double>();
        foreach (var items in res)
        {
          Counts.Add(items.Count());
        }
        var series = new ColumnSeries
        {
          Title = item.FirstOrDefault().Created.Value.Year.ToString(),
          Values = new ChartValues<double>(Counts.ToArray())
        };
        SeriesCollection.Add(series);
        Counts.Clear();
      }

      Labels = new string[r.ToList().Count];
      List<string> labels = new List<string>();
      foreach (var item in r.ToList())
      {
        labels.Add(item.TagName);
      }

      Labels = labels.ToArray();

      Formatter = value => value.ToString("N");

      DataContext = this;
    }

    public SeriesCollection SeriesCollection { get; set; }
    public string[] Labels { get; set; }
    public Func<double, string> Formatter { get; set; }
  }
}