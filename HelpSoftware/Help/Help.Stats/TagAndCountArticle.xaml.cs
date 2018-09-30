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
  public partial class TagAndCountArticle : Window
  {
    public TagAndCountArticle()
    {
      InitializeComponent();
      var client = new ArticleService.ArticleWCFServiceClient();
      var res = client.GetAll();
      var rus = (List<Article>)JSONSerializer.JSONToObject(res, typeof(List<Article>));
      var grp = rus.GroupBy(x => x.Tags).Select(d => d.ToList()).ToList();
      foreach (var item in grp)
      {
        if (item.FirstOrDefault().Tags != null)
        {
          List<int> i = new List<int>();
          i.Add(item.Count);
          test.Series.Add(new PieSeries() { Title = item.FirstOrDefault().Tags.FirstOrDefault().TagName, DataLabels = true, Values = new ChartValues<int>(i) });
        }
        else
        {
          List<int> i = new List<int>();
          i.Add(item.Count);
          test.Series.Add(new PieSeries() { Title = "Null", DataLabels = true, Values = new ChartValues<int>(i) { } });
        }
      }
    }

    public Func<ChartPoint, string> PointLabel { get; set; }

    private void Chart_OnDataClick(object sender, ChartPoint chartPoint)
    {
      var chart = (LiveCharts.Wpf.PieChart)chartPoint.ChartView;
      //clear selected slice.
      foreach (PieSeries series in chart.Series)
        series.PushOut = 0;

      var selectedSeries = (PieSeries)chartPoint.SeriesView;
      selectedSeries.PushOut = 8;
    }
  }
}