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
using System.Windows.Shapes;

namespace Help
{
  public partial class ShowTag : Window
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