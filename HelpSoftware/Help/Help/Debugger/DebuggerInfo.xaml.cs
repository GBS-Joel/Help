using Help.Library;
using System.Windows;
using System.Windows.Controls;

namespace Help.Debugger
{
  /// <summary>
  /// Interaktionslogik für DebuggerInfo.xaml
  /// </summary>
  public partial class DebuggerInfo : UserControl
  {
    public ClientInfo ClientInfo { get; set; }

    public DebuggerController Controller { get; set; }

    public DebuggerInfo(DebuggerController Controller)
    {
      InitializeComponent();
      DataContext = this;
      this.Controller = Controller;
      ClientInfo = Controller.GetClientInfo();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
    }
  }
}