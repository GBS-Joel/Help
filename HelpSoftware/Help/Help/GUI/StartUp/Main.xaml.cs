using Help.Library;
using System.Windows.Input;

namespace Help
{
  public partial class Main : HelpUserControl
  {
    public Main()
    {

      InitializeComponent();
      Model = new MainModel();
      Model.LoadData();
      DataContext = Model;
      foreach (var item in ((MainModel)Model).DiscoverArticles)
      {
        stackpaneldisc.Children.Add(new DiscoverArticle(item));
      }
    }

    public override void DisplayData()
    {
      base.DisplayData();

    }

    private void tbSearchText_KeyDown(object sender, KeyEventArgs e)
    {

    }
  }
}