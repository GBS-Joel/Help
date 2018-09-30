using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Help.Library
{
  public class HelpTextBoxID : HelpTextBox
  {
    protected override void OnInitialized(EventArgs e)
    {
      base.OnInitialized(e);
      TryLoadIDForCurrentElement();
    }

    public void TryLoadIDForCurrentElement()
    {
      AppContext.Logger.Debug("Try Load ID For Current Winow " + Name);
      var id = AppContext.WindowManagerInstance.CurrentOpenElement?.GetModel()?.GetID();
      if (id == null)
      {
        Text = "0";
        Background = Brushes.LightCyan;
        AppContext.Logger.Warn("Could Not Load ID For Window", AppContext.WindowManagerInstance.CurrentOpenElement.Name);
      }
      else
      {
        Text = id.ToString();
      }
    }
  }
}