using System.Windows.Controls;
using System.Windows;

namespace Help.Library
{
  public class HelpTextBox : TextBox
  {
    public bool AffectIsSavedState { get; set; } = true;

    public HelpTextBox()
    {
      VerticalAlignment = VerticalAlignment.Top;
      HorizontalAlignment = HorizontalAlignment.Left;
      FontSize = 18;
      Height = 30;
      VerticalContentAlignment = VerticalAlignment.Center;
      TextChanged += HelpTextBox_TextChanged;
    }

    private void HelpTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
      if (AffectIsSavedState && IsLoaded)
      {
        AppContext.WindowManagerInstance.MarkCurrentElementAsNotSaved();
      }
    }
  }
}