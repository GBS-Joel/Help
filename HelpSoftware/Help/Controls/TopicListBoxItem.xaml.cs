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
  public partial class TopicListBoxItem : ListBoxItem
  {
    public Topic CurrentTopic { get; set; }

    public TopicListBoxItem(Topic Topic)
    {
      InitializeComponent();
      CurrentTopic = Topic;
      LoadTopicInfo();
      DataContext = this;
    }

    public void LoadTopicInfo()
    {

    }
  }
}
