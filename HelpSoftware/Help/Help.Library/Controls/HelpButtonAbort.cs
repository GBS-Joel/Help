using System;
using System.Linq;
using System.Windows;

namespace Help.Library.Controls
{
  public class HelpButtonAbort : HelpButton
  {
    private bool _initialLoadPerformed;
    private Action ActionOnClick;
    private HelpButtonSave _PartnerSaveButton;

    public HelpButtonAbort()
    {
      Loaded += HelpButtonAbort_Loaded;
      ActionOnClick = AppContext.WindowManagerInstance.CloseActiveWindow;
    }

    protected override void OnClick()
    {
      base.OnClick();
      ActionOnClick.Invoke();
    }

    private void HelpButtonAbort_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
      if (_initialLoadPerformed) return;
      _initialLoadPerformed = true;
      var SaveButton = LogicalTreeHelper.GetChildren(Parent).OfType<HelpButtonSave>().ToList();
      if (SaveButton.Count == 1)
      {
        _PartnerSaveButton = SaveButton[ 0 ];
        _PartnerSaveButton.IsEnabledChanged += new DependencyPropertyChangedEventHandler(HelpButtonSave_IsEnabledChanged);
      }
      Content = AppContext.TranslationManagerInstance.Translate("Abbrechen");
      DisplayStatus();
    }

    void HelpButtonSave_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
      DisplayStatus();
    }

    private void DisplayStatus()
    {
      if (_PartnerSaveButton != null)
        if (_PartnerSaveButton.IsEnabled)
        {
          Content = AppContext.TranslationManagerInstance.Translate("Abbrechen");
        }
        else
        {
          Content = AppContext.TranslationManagerInstance.Translate("Schliessen");
        }
    }
  }
}