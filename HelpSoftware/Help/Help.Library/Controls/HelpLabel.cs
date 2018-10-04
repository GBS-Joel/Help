using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace Help.Library
{
  public class HelpLabel : Label
  {
    public HelpLabel()
    {
      VerticalAlignment = VerticalAlignment.Top;
      HorizontalAlignment = HorizontalAlignment.Left;
      FontSize = 16;
      if (AppThemeHandler.UseDarkTheme)
        Foreground = Brushes.White;
      else
        Foreground = Brushes.Black;
    }
  }
}