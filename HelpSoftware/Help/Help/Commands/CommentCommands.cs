namespace Help
{
  public static class CommentCommands
  {
    public static bool EditComment_CanExecute(object sender)
    {
      return true;
    }

    //Parameter is CurrentCommentListBoxItem
    public static void EditComment_Executed(object sender)
    {
      CommentListBoxItem item = (CommentListBoxItem)sender;
    }
  }
}