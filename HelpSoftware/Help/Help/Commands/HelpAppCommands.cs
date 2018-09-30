using Help.Library;

namespace Help
{
  public class HelpAppCommands
  {
    public static void InitInstance()
    {
      Instance = new HelpAppCommands();
    }

    public static HelpAppCommands Instance { get; set; }

    public static readonly HelpCommand EditComment = new
        HelpCommand(CommentCommands.EditComment_Executed, CommentCommands.EditComment_CanExecute);
  }
}