using System.Windows.Controls;

namespace Help.Debugger
{
  public partial class DebuggerDatabase : UserControl
  {
    public static ListBox OutputBox { get; set; }

    public DebuggerDatabase()
    {
      InitializeComponent();
      OutputBox = output;
    }

    public static void LogDebug(object message)
    {
      if (OutputBox != null)
      {
        OutputBox.Items.Add(new ListBoxItem() { Content = message });
      }
    }
  }
}