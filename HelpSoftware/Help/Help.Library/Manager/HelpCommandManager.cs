using System;

namespace Help.Library
{
  /// <summary>
  /// Responsible to Assign the Button to the valid Command
  /// </summary>
  public class HelpCommandManager
  {
    //This is to store the Commmand in the Database and reload it for later use
    //A User cann create his own custom Ribbon COnfig

    private static HelpDatensatzCommands HelpDatensatzCommands { get; set; }

    public HelpCommandManager()
    {
      HelpDatensatzCommands = new HelpDatensatzCommands();
    }

    //Name is
    // Ribbon  GroupBox Command
    //DatensatzCommands_New
    //HelpDatensatzCommands_New
    public HelpCommand GetCommandFromName(string Name)
    {
      string[ ] name = Name.Split('_');
      switch (Name[ 0 ].ToString())
      {
        case "HelpDatensatzCommands":
          return HelpDatensatzCommands.GetCommandByName(name[ 1 ]);
        case "New":
          return HelpDatensatzCommands.New;
        default:
          throw new CommandNotFoundException(Name);
      }
    }
  }
}