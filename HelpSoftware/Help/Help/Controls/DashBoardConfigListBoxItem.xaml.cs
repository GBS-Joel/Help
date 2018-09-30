using Help.EF;
using Help.Library;
using System.Windows.Controls;
using System.Windows.Input;

namespace Help
{
  public partial class DashBoardConfigListBoxItem : UserControl
  {
    public DashBoard CurrentDashBoard { get; set; }

    public DashBoardUser CurrentConfig { get; set; }

    public bool IsTicked { get; set; }

    private DashBoardConfigListBoxItem()
    {
      InitializeComponent();
    }

    public DashBoardConfigListBoxItem(DashBoard Board)
    {
      InitializeComponent();
      CurrentDashBoard = Board;
      LoadUserDashBoard();
      DataContext = this;
    }

    private void LoadUserDashBoard()
    {
      int ID_User, ID_DashBoard;
      ID_User = AppContext.LoggedInUser.ID_User;
      ID_DashBoard = CurrentDashBoard.ID_DashBoard;
      var res = HelpService.GetService<DashBoardUserService>().GetCurrentDashBoardConf(ID_User, ID_DashBoard);
      if (res != null)
      {
        CurrentConfig = res;
        tbName.Text = CurrentDashBoard.Name;
        tswitch.IsChecked = true;
        tbDesc.Text = CurrentDashBoard.Description;
      }
    }

    private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
      tswitch.IsChecked = !tswitch.IsChecked;
    }

    private void tswitch_Checked(object sender, System.Windows.RoutedEventArgs e)
    {
      IsTicked = true;
    }

    private void tswitch_Unchecked(object sender, System.Windows.RoutedEventArgs e)
    {
      IsTicked = false;
    }
  }
}