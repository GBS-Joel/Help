using Help.EF;
using Help.Library;
using System.Collections.Generic;
using System.Linq;

namespace Help
{
  public partial class ShowTag : HelpUserControl
  {
    public List<Tag> Tags { get; set; }

    public ShowTag()
    {
      InitializeComponent();
      DataContext = this;
      LoadTags();
    }

    public void LoadTags()
    {
      var qry = from tag in HelpContext.Instance.Tags
                select tag;
      Tags = qry.ToList();
      List<TagListBoxItem> itemsbox = new List<TagListBoxItem>();
      foreach (Tag item in Tags)
      {
        TagListBoxItem ib = new TagListBoxItem(item);
        ib.Width = lbtags.Width;
        itemsbox.Add(ib);
      }
      lbtags.ItemsSource = itemsbox;
    }
  }
}