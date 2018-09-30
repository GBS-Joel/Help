using System;

namespace Help.Library
{
  public class HelpDatensatzCommands : IHelpCommandDefinition
  {
    public static HelpCommand New = new
      HelpCommand(RibbonGroupBoxDatensatzCommands.New_Executed, RibbonGroupBoxDatensatzCommands.New_CanExecute);

    public static HelpCommand ViewChanges = new
      HelpCommand(RibbonGroupBoxDatensatzCommands.ViewChanges_Executed, RibbonGroupBoxDatensatzCommands.ViewChanges_CanExecute);

    public HelpCommand GetCommandByName(string Name)
    {
      throw new NotImplementedException();
    }
  }

  public static class RibbonGroupBoxDatensatzCommands
  {
    public static bool ViewChanges_CanExecute(object parameter)
    {
      return true;
    }

    public static void ViewChanges_Executed(object parameter)
    {
    }

    public static bool New_CanExecute(object parameter)
    {
      return AppContext.WindowManagerInstance.CurrentOpenElement.CanNewBeExecuted();
    }

    public static void New_Executed(object sender)
    {
      //TODO: Refactor this code to be save
      AppContext.WindowManagerInstance.OpenNewWindow(((IAllowNew)AppContext.WindowManagerInstance.CurrentOpenElement).GetNewWindow());
      //AppContext.WindowManagerInstance.OpenNewWindow(AppContext.WindowManagerInstance.CurrentOpenElement.GetNewWindow());
    }
  }
}