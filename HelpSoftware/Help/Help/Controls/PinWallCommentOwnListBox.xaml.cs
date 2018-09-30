using Help.EF;
using System.Windows.Controls;

namespace Help
{
  public partial class PinWallCommentOwnListBox : ListBoxItem
  {
    public PinWallComment CurrentComment { get; set; }

    private PinWallCommentOwnListBox()
    {
      InitializeComponent();
    }

    public PinWallCommentOwnListBox(PinWallComment Comment)
    {
      CurrentComment = Comment;
    }
  }
}