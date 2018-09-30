using Help.Library;
using System.Windows;
using System.Windows.Controls;

namespace Help.Debugger
{
  /// <summary>
  /// Interaktionslogik für DebuggerTranslation.xaml
  /// </summary>
  public partial class DebuggerTranslation : UserControl
  {
    public DebuggerTranslation()
    {
      InitializeComponent();
    }

    public void ChangeLanguage()
    {
    }

    //Deutsch
    private void RadioButton_Checked(object sender, RoutedEventArgs e)
    {
      AppContext.TranslationManagerInstance.ChangeAppLanguage(AppLanguage.German);
    }

    //Englisch
    private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
    {
      AppContext.TranslationManagerInstance.ChangeAppLanguage(AppLanguage.Englisch);
    }
  }
}