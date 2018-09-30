namespace Help.Library
{
  public class HelpDatensatzCommandss : IHelpCommandDefinition
  {
    //public static HelpCommand New = new
    //  HelpCommand(DatensatzCommands.New_Executed, DatensatzCommands.New_CanExecute);

    //public static HelpCommand ViewChanges = new
    //  HelpCommand(DatensatzCommands.ViewChanges_Executed, DatensatzCommands.ViewChanges_CanExecute);

    public HelpCommand GetCommandByName(string Name)
    {
      switch (Name)
      {
        //case "New":
        //  return New;
        //case "ViewChanges":
        //  return ViewChanges;
        default:
          throw new CommandNotFoundException(Name);
      }
    }
  }
}