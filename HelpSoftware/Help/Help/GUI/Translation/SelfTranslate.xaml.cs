using Help.EF;
using Help.Library;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Help
{
  public partial class SelfTranslate : HelpUserControl
  {
    public Translation CurrentTran { get; set; }

    public string Deutsch { get; set; }

    public string Englisch { get; set; }

    public bool LoadAllData { get; set; } = true;

    public SelfTranslate()
    {
      InitializeComponent();
      DataContext = this;
    }

    public void LoadData(bool AllData)
    {
      List<Translation> transres = new List<Translation>();
      if (AllData)
      {
        transres = HelpService.GetService<TranslationService>().GetAllEntities();
      }
      else
      {

        transres = HelpService.GetService<TranslationService>().GetAllTranslationsWithMissingEnglischText();
      }

      List<TranslateListBoxItem> Items = new List<TranslateListBoxItem>();
      foreach (var item in transres)
      {
        TranslateListBoxItem box = new TranslateListBoxItem(item);
        box.Width = tbTrans.ActualWidth - 5;
        Items.Add(box);
      }
      tbTrans.ItemsSource = Items;
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      LoadData(true);
    }

    public void UpdateWindow()
    {
      Deutsch = CurrentTran.GermanText;
      Englisch = CurrentTran.EnglischText;
    }

    private void tbTrans_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (tbTrans.SelectedItem != null)
      {
        CurrentTran = ((TranslateListBoxItem)tbTrans.SelectedItem).CurrentTranslation;
        UpdateWindow();
      }
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      CurrentTran.EnglischText = Englisch;
      HelpContext.Instance.Entry(CurrentTran).State = System.Data.Entity.EntityState.Modified;
      HelpContext.Instance.SaveChanges();
      LoadData(LoadAllData);
    }

    private void ToggleSwitch_Checked(object sender, RoutedEventArgs e)
    {
      LoadData(false);
      LoadAllData = false;
    }

    private void chwords_Unchecked(object sender, RoutedEventArgs e)
    {
      LoadData(true);
      LoadAllData = true;
    }
  }
}