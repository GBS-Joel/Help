using System.Windows;
using System.Windows.Controls;

namespace Help.Library
{
  public class HelpButton : Button
  {
    public HelpButton()
    {
      Loaded += HelpButton_Loaded;
    }

    private bool _isLoaded;

    public virtual bool IsPermissionHandledInternally { get; set; }

    private void HelpButton_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
      if (!AppContext.IsAtRuntime) return;
      if (_isLoaded) return;
      _isLoaded = true;
      AppContext.Logger.Debug("Loaded Button " + Name);
    }
  }
}