using Help.EF;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Help.Stats
{
  public partial class GaugeReviewedArticle : UserControl
  {
    public GaugeReviewedArticle()
    {
      InitializeComponent();

      HelpContext.InitInstance();

      var qry = from a in HelpContext.Instance.Articles
                select a;

      List<Article> all = qry.ToList();

      List<Article> reviewed = qry.Where(x => x.IsReviewed == true).ToList();

      int countall = all.Count;
      int countrev = reviewed.Count;

      int percentfilled = countrev * 100 / countall;
      test.Value = (double)percentfilled;

      test.LabelFormatter = value => string.Format("{0}{1}", value, "%");
    }
  }
}