using Help.EF;

namespace Help.Library
{
  public class BackstageButtonClose : IBackstageButtonDef
  {
    public BackstageButtonClose()
    {
      BackstageButtonDef = new BackstageButtonDef()
      {
        SeperatorAfter = false,
        Order = 99,
        IsFirst = false,
        IsLast = true,
        Header = "Schliessen",
        UID = "BackstageClose",
        Name = "BackstageClose",
        KeyTip = "X",
        Command = "Close",
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