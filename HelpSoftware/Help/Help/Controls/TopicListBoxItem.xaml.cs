using Help.EF;
using System.Windows.Controls;

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