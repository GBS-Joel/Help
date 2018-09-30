using Help.EF;
using System.Windows.Controls;
using System.Windows.Media;

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