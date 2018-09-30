using LiveCharts;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Help.Stats
{
  public class ReverseConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      return ((SeriesCollection)value).Reverse();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}