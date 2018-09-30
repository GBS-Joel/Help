using Help.Library;
using System;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace Help.Debugger
{
  public partial class DebuggerTools : UserControl
  {
    public DebuggerTools()
    {
      InitializeComponent();
      LoadWindows();
    }

    private void btnRunGarbage_Click(object sender, RoutedEventArgs e)
    {
      GC.Collect();
      GC.Collect();
    }

    public void LoadWindows()
    {
      var type = typeof(HelpUserControl);
      var types = AppDomain.CurrentDomain.GetAssemblies()
          .SelectMany(s => s.GetTypes())
          .Where(p => type.IsAssignableFrom(p));
      ItemsWindow.ItemsSource = types.ToList();
    }


    private void Button_Click(object sender, RoutedEventArgs e)
    {
      string asname = @".\Help\HelpSoftware\Help\Help\bin\Debug\Help.exe";
      AppContext.WindowManagerInstance.OpenNewWindow((IModuleElement)Activator.CreateComInstanceFrom(asname, ItemsWindow.Text));
    }
  }
}