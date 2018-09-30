using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Help
{
  public partial class TagListBoxItem : ListBoxItem
  {
    public Tag CurrentTag { get; set; }

    private TagListBoxItem()
    {
      InitializeComponent();
    }

    public TagListBoxItem(Tag Tag)
    {
      InitializeComponent();
      CurrentTag = Tag;
      LoadTagInfo();
      DataContext = this;
    }

    public void LoadTagInfo()
    {
      var color = (Color)ColorConverter.ConvertFromString(CurrentTag.ColorString);
      SolidColorBrush brush = new SolidColorBrush(color);
      tbTitle.Foreground = brush;
    }
  }
}