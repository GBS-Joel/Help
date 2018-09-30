using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Help.Library
{
  public class HelpCheckComboBox : HelpCheckComboBoxBase
  {
    public bool AffectIsSaveState { get; set; } = false;

    static HelpCheckComboBox()
    {
      DefaultStyleKeyProperty.OverrideMetadata(typeof(HelpCheckComboBox), new FrameworkPropertyMetadata((typeof(HelpCheckComboBox))));
    }

    public HelpCheckComboBox() : base(false)
    {
      OnChanged = Changed;
    }

    public void Changed()
    {
      if (AffectIsSaveState)
        AppContext.WindowManagerInstance.MarkCurrentElementAsNotSaved();
    }
  }
}