using System;

namespace Help.Library
{
  public class HelpLinkCommands : IHelpCommandDefinition
  {
    public static HelpCommand OpenLink = new
      HelpCommand(LinkCommands.OpenLink_Execute, LinkCommands.OpenLink_CanExecute);

    public HelpCommand GetCommandByName(string Name)
    {
      throw new NotImplementedException();
    }
  }  
}