using Help.EF;

namespace Help.Library
{
  public class BackstageButtonHelp : IBackstageButtonDef
  {
    public BackstageButtonHelp()
    {
      BackstageButtonDef = new BackstageButtonDef()
      {
        SeperatorAfter = false,
        Order = 0,
        IsFirst = true,
        IsLast = false,
        Header = "Hilfe",
        UID = "BackstageHelp",
        Name = "BackstageHelp",
        KeyTip = "H",
        Command = "Help",
        IsDefault = true,
      };
    }

    public BackstageButtonDef BackstageButtonDef { get; set; }

    public BackstageButtonDef GetBackStageButtonDef()
    {
      return BackstageButtonDef;
    }
  }
}