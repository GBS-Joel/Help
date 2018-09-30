using Help.Library;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Help
{
  public partial class StartNotLoggedIn : HelpUserControl
  {
    public StartNotLoggedIn()
    {
      Model = new StartNotLoggedInModel();
      Title = "Start";
      Name = "StartNotLoggedIn";

      RequiredPermission = HelpPermission.None;
      WindowType = WindowType.Detail;

      InitializeComponent();
    }

    public override void DisplayData()
    {
      base.DisplayData();
      foreach (var item in ((StartNotLoggedInModel)Model).Topics)
      {
        Tags.Children.Add(new HelpLabel()
        {
          Content = item.Name,
          VerticalAlignment = VerticalAlignment.Top,
          HorizontalAlignment = HorizontalAlignment.Left,
          Margin = new Thickness(25),
          FontSize = 26,
        });
      }
      foreach (var item in ((StartNotLoggedInModel)Model).Tags)
      {
        Topics.Children.Add(new HelpLabel()
        {
          Content = item.TagName,
          VerticalAlignment = VerticalAlignment.Top,
          HorizontalAlignment = HorizontalAlignment.Left,
          Margin = new Thickness(25),
          FontSize = 26,
        });
      }
      if (((StartNotLoggedInModel)Model).Tags.Count == 0)
      {
        StackPanel panel = new StackPanel();

        panel.Children.Add(new HelpLabel()
        {
          Content = "There are no Tags!",
          FontSize = 20,
          VerticalAlignment = VerticalAlignment.Top,
          HorizontalAlignment = HorizontalAlignment.Center
        });
        HelpLabel l = new HelpLabel()
        {
          Content = "Create a New Tag!",
          FontSize = 20,
          Foreground = Brushes.Blue,
          VerticalAlignment = VerticalAlignment.Top,
          HorizontalAlignment = HorizontalAlignment.Center
        };
        l.MouseUp += L_MouseUp;
        panel.Children.Add(l);
        Tags.Children.Add(panel);
      }
      if (((StartNotLoggedInModel)Model).Topics.Count == 0)
      {
        StackPanel p = new StackPanel();

        p.Children.Add(new HelpLabel()
        {
          Content = "There are no Topics!",
          FontSize = 20,
          VerticalAlignment = VerticalAlignment.Top,
          HorizontalAlignment = HorizontalAlignment.Center
        });

        HelpLabel o = new HelpLabel()
        {
          Content = "Create Topic",
          FontSize = 20,
          Foreground = Brushes.Blue,
          VerticalAlignment = VerticalAlignment.Top,
          HorizontalAlignment = HorizontalAlignment.Center
        };
        o.MouseUp += O_MouseUp;

        p.Children.Add(o);
        Topics.Children.Add(p);
      }
    }

    private void O_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
      MessageBox.Show("Create Topic");
    }

    private void L_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
      MessageBox.Show("Create Tag");
    }

    private void GroupBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
      MessageBoxHelper instance = new MessageBoxHelper();
      instance.ShowMessageBox("Group Box");
    }
  }
}