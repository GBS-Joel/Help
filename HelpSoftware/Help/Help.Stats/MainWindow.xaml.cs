using System.Windows;

namespace Help.Stats
{
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();

      //HelpContext.InitInstance();

      //var qry = from a in HelpContext.Instance.Articles
      //          select a;

      //List<Article> all = qry.ToList();

      //List<Article> reviewed = qry.Where(x => x.IsReviewed == true).ToList();

      //int countall = all.Count;
      //int countrev = reviewed.Count;

      //int percentfilled = countrev * 100 / countall;
      //test.Value = (double)percentfilled;

      //test.LabelFormatter = value => string.Format("{0}{1}", value, "%");

      ControlCenter center = new ControlCenter();
      center.Show();

      //var qry = from wi in HelpContext.Instance.Translations
      //          select wi;
      //var a = qry.ToList();

      //List<Translation> translated = a.Where(x => x.EnglischText != "").ToList();

      //List<Translation> Nottranslated = a.Where(x => x.EnglischText == "").ToList();

      //int countran = translated.Count;
      //int countnotran = Nottranslated.Count;

      //int percentfilled = countran * 100 / a.Count;
      //test.Value = (double)percentfilled;

      //test.LabelFormatter = value => string.Format("{0}{1}", value, "%");
    }
  }
}