using Help.EF;

namespace Help.Library
{
  public class LinkCommands : IHelpCommandDefinition
  {
    public static HelpCommand OpenLink = new
      HelpCommand(LinkCommandsImplementation.OpenLink_Execute, LinkCommandsImplementation.OpenLink_CanExecute);
  }

  public static class LinkCommandsImplementation
  {
    public static bool OpenLink_CanExecute(object parameter)
    {
      return true;
    }

    public static void OpenLink_Execute(object parameter)
    {
      //Is the object a link item?
      //We just assume is an link item
      AppContext.LinkManagerInstance.OpenLink((LinkItem)parameter);
    }
  }
}