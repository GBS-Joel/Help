using System.Windows;

namespace Help.Stats
{
  public partial class ControlCenter : Window
  {
    public ControlCenter()
    {
      InitializeComponent();
      WrongTran.Content = new GaugeWrongTranslation();
      test1.Content = new GaugeReviewedArticle();
      test2.Content = new GaugeBugReports();
      test3.Content = new GaugeNewestArticles();
      test4.Content = new GaugeLikedArticles();
      test5.Content = new GaugeFavedArticles();
      test6.Content = new GaugeProposedArticles();
      test7.Content = new GaugeLogins();
      test8.Content = new GaugeMailActivity();
    }
  }
}