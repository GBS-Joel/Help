using Help.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Help.Library
{
  public class HelpComboBox : ComboBox
  {
    //Example: ActivityAction
    private string WBHerkunft { get; set; }

    public static readonly DependencyProperty HerkunftProperty;

    public HelpComboBox()
    {
      IsEditable = true;
      IsReadOnly = false;
      IsTextSearchEnabled = false;
      StaysOpenOnEdit = true;
      IsTabStop = false;
      IsSynchronizedWithCurrentItem = true;
      Loaded += HelpComboBox_Loaded;
    }

    private void HelpComboBox_Loaded(object sender, RoutedEventArgs e)
    {
      if (AppContext.IsAtRuntime) return;
    }

    public void LoadItems(string WB)
    {
      var qry = from a in HelpContext.Instance.WertebereichDefs
                where a.Name == WB
                select a;
    }
  }
}