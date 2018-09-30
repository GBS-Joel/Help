using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Help.Library
{
  public partial class ModuleListBoxItem : UserControl
  {
    public ModuleListBoxItem()
    {
      InitializeComponent();
    }

    public ModuleListBoxItem(string Name)
    {
      InitializeComponent();
      name.Text = Name;
      MouseDoubleClick += ModuleListBoxItem_MouseDoubleClick; ;
      VerticalAlignment = VerticalAlignment.Stretch;
    }

    private void ModuleListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
      AppContext.ModuleManagerInstance.ToggleSideBar();
    }
  }
}