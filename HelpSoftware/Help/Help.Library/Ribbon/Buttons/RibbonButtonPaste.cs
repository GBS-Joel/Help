using Help.EF;

namespace Help.Library
{
  public class RibbonButtonPaste : IRibbonButtonDef
  {
    public RibbonButtonDef RibbonButtonDef { get; set; }

    public RibbonButtonPaste()
    {
      RibbonButtonDef = new RibbonButtonDef()
      {
        DisplayName = "Aktualisieren",
        Name = "RibbonButtonAktualisieren",
        UID = "RibbonButtonAktualisieren",
        KeyTip = "A",
        ImageLarge = "Black_48x48_Update",
        ImageSmall = "Black_24x24_Update",
        ImageTiny = "Black_18x18_Update",
        ScreenTippTitle = "Datensatz Aktualisieren",
        Command = "App_Refresh",
        HelpTopic = "Refresh",
        ScreenTippText = "Updates the Current Window"
      };
    }

    public RibbonButtonDef GetRibbonButtonDef()
    {
      return RibbonButtonDef;
    }
  }
}