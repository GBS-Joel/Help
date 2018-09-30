using Help.EF;
using System.Windows.Controls;

namespace Help
{
  public partial class PinWallCommentOtherListBoxItem : ListBoxItem
  {
    public PinWallComment CurrentPinWallComment { get; set; }

    public string AuthorString { get; set; }

    public string TimeString { get; set; }

    public PinWallCommentOtherListBoxItem(PinWallComment comment)
    {
      DataContext = this;
      CurrentPinWallComment = comment;
      if (CurrentPinWallComment.IsAnonymous)
      {
        AuthorString = "Anonym";
      }
      else
      {
        AuthorString = CurrentPinWallComment.Author.Vorname + " " + CurrentPinWallComment.Author.Nachname;
      }
      TimeString = CurrentPinWallComment.CommentTime.ToShortDateString();
    }
  }
}