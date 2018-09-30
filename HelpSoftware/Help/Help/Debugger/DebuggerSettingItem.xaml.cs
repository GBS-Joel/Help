using Help.EF;
using System.Windows.Controls;

namespace Help.Debugger
{
  public partial class DebuggerSettingItem : UserControl
  {
    public DebuggerSettingItem(SystemSetting setting)
    {
      InitializeComponent();
      DataContext = this;
    }
  }
}