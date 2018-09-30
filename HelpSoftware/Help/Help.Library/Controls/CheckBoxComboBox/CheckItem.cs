using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Library
{
  public class CheckItem : INotifyPropertyChanged
  {
    public object KeyValue { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

    public int Index { get; set; }

    public string Display { get; set; }

    private bool isChecked = false;

    public bool IsChecked
    {
      get { return isChecked; }
      set
      {
        if (isChecked != value)
        {
          isChecked = value;
          RaisePropertyChanged("IsChecked");
        }
      }
    }

    public CheckItem()
    {
      IsChecked = false;
    }

    public void RaisePropertyChanged(string propertyName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public CheckItem(object KeyValue, string display)
    {
      this.IsChecked = false;
      this.KeyValue = KeyValue;
      this.Display = display;
    }
  }
}
