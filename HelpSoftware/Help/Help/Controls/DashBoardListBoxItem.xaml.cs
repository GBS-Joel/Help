using Help.EF;
using System.Windows.Controls;

namespace Help
{
  public partial class DashBoardListBoxItem : ListBoxItem
  {
    public DashBoard CurrentDashBoard { get; set; }

    public string ElementTitle { get; set; }

    public DashBoardListBoxItem(DashBoard item)
    {
      InitializeComponent();
      CurrentDashBoard = item;
      DataContext = this;
      ElementTitle = CurrentDashBoard.Name;
      if (CurrentDashBoard.IsPublic)
      {
        icon.Kind = MahApps.Metro.IconPacks.PackIconFontAwesomeKind.LockOpenSolid;
      }
      else
      {
        icon.Kind = MahApps.Metro.IconPacks.PackIconFontAwesomeKind.LockSolid;
      }
    }
  }
}