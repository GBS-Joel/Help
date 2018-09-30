using System.Windows;
using System.Windows.Controls;

namespace Help.Library
{
  public class ModuleManager
  {
    public DockPanel SideBar { get; set; }

    public bool IsMinimized { get; set; }

    public void SetSideBar(DockPanel Panel)
    {
      SideBar = Panel;
      IsMinimized = false;
    }

    public void OpenModule(string Name)
    {
      MessageBox.Show(Name);
    }

    public void ToggleSideBar()
    {
      if (IsMinimized)
      {
        AppContext.ModuleManagerInstance.SideBar.Width = 200;
        AppContext.ModuleManagerInstance.SideBar.HorizontalAlignment = HorizontalAlignment.Left;
        IsMinimized = false;
      }
      else
      {
        AppContext.ModuleManagerInstance.SideBar.Width = 10;
        AppContext.ModuleManagerInstance.SideBar.HorizontalAlignment = HorizontalAlignment.Left;
        IsMinimized = true;
      }
    }
  }
}