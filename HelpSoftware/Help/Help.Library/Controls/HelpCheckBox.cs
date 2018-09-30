using System;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace Help.Library.Controls
{
  public class HelpCheckBox : CheckBox, IChangeableHelpControl
  {
    public bool HasLabel { get; set; }

    public string Text { get; set; }

    protected override void OnInitialized(EventArgs e)
    {
      base.OnInitialized(e);
      VerticalAlignment = VerticalAlignment.Center;
      Text = Content.ToString();
      CalulateHasLabel(Text);
    }

    private void CalulateHasLabel(string value)
    {
      HasLabel = !string.IsNullOrWhiteSpace(value);
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
      base.OnKeyDown(e);

      if (e.Key == Key.Delete)
      {
        if (IsChecked == true)
        {
          IsChecked = false;
          OnControlChanged();
        }
      }
    }

    protected override void OnChecked(RoutedEventArgs e)
    {
      base.OnChecked(e);
      OnControlChanged();
    }

    public void OnControlChanged()
    {
      AppContext.WindowManagerInstance.MarkCurrentElementAsNotSaved();
    }
  }
}