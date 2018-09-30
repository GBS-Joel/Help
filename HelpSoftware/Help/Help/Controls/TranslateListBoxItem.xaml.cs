using Help.EF;
using System.Windows.Controls;

namespace Help
{
  public partial class TranslateListBoxItem : ListBoxItem
  {
    public Translation CurrentTranslation { get; set; }

    public string Deutsch { get; set; }

    public string Englisch { get; set; }

    public TranslateListBoxItem(Translation tran)
    {
      InitializeComponent();
      CurrentTranslation = tran;
      Deutsch = tran.GermanText;
      if (CurrentTranslation.EnglischText == "")
      {
        Englisch = "?????????";
      }
      else
      {
        Englisch = tran.EnglischText;
      }
      DataContext = this;
    }
  }
}