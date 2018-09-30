using Help.EF;

namespace Help.Library
{
  public class BackstageButtonSetting : IBackstageButtonDef
  {
    public BackstageButtonSetting()
    {
      BackstageButtonDef = new BackstageButtonDef()
      {
        SeperatorAfter = false,
        Order = 99,
        IsFirst = false,
        IsLast = true,
        Header = "Einstellungen",
        UID = "BackstageSetting",
        Name = "BackstageSetting",
        KeyTip = "I",
        Command = "Setting",
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