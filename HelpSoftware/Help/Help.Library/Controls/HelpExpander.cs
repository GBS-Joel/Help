using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Help.Library
{
  public class HelpExpander : HeaderedContentControl
  {
    public string IsLoadingText { get; set; }

    public HelpExpander()
    {
      Loaded += HelpExpander_Loaded;
      IsLoadingText = AppContext.TranslationManagerInstance.Translate("Inhalt wird Geladen");
    }

    private void HelpExpander_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
      if (!AppContext.IsAtRuntime) return;


    }

    public bool IsExpanded { get; set; }

    public bool COntainsData { get; set; }



    public event EventHandler Expandend;

    public event EventHandler Collapsed;
  }
}