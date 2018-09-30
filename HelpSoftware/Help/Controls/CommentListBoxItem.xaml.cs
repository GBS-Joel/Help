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
  public partial class CommentListBoxItem : ListBoxItem
  {
    public ArticleComment CurrentComment { get; set; }

    public CommentListBoxItem()
    {
      InitializeComponent();
    }

    public CommentListBoxItem(ArticleComment Comment)
    {
      InitializeComponent();
      CurrentComment = Comment;
      LoadComment();
      DataContext = this;
    }

    public void LoadComment()
    {

    }
  }
}
