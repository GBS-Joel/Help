using MahApps.Metro.Controls;
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
  public partial class ShowTopic : MetroWindow
  {
    public ShowTopic()
    {
      InitializeComponent();
      Loaded += ShowTopic_Loaded;
    }

    private void ShowTopic_Loaded(object sender, RoutedEventArgs e)
    {
      LoadTopics();
    }

    public void LoadTopics()
    {
      var qry = from t in HelpContext.Instance.Topics
                select t;

      List<Topic> lstTopics = qry.ToList();

      int count = lstTopics.Count;
      List<Topic> lstLeft = new List<Topic>();
      List<Topic> lstRight = new List<Topic>();
      for (int i = 0; i < count / 2; i++)
      {
        lstLeft.Add(lstTopics[ i ]);
      }
      foreach (var item in lstTopics)
      {
        if (!lstLeft.Contains(item))
        {
          lstRight.Add(item);
        }
      }

      List<TopicListBoxItem> boxitemsleft = new List<TopicListBoxItem>();
      List<TopicListBoxItem> boxitemsright = new List<TopicListBoxItem>();
      foreach (var item in lstLeft)
      {
        TopicListBoxItem boxitem = new TopicListBoxItem(item);
        boxitem.Width = lbLeft.ActualWidth;
        boxitemsleft.Add(boxitem);
      }
      lbLeft.ItemsSource = boxitemsleft;

      foreach (var item in lstRight)
      {
        TopicListBoxItem boxitem = new TopicListBoxItem(item);
        boxitem.Width = lbRight.ActualWidth;
        boxitemsright.Add(boxitem);
      }
      lbRight.ItemsSource = boxitemsright;
    }

    private void lbLeft_LostFocus(object sender, RoutedEventArgs e)
    {
      lbLeft.SelectedItem = null;
    }

    private void lbRight_LostFocus(object sender, RoutedEventArgs e)
    {
      lbRight.SelectedItem = null;
    }
  }
}