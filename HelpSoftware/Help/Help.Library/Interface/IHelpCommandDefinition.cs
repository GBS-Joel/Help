namespace Help.Library
{
  public interface IHelpCommandDefinition
  {
    HelpCommand GetCommandByName(string Name);
  }
}