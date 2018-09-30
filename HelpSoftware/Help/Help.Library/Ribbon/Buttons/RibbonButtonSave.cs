using Help.EF;

namespace Help.Library
{
  public class RibbonButtonSave : IRibbonButtonDef
  {
    public RibbonButtonSave()
    {
      RibbonButtonDef = new RibbonButtonDef()
      {
        DisplayName = "Speichern",
        Name = "RibbonButtonSave",
        UID = "RibbonButtonSave",
        KeyTip = "S",
        ImageLarge = "Black_48x48_Save",
        ImageSmall = "Black_24x24_Save",
        ImageTiny = "Black_18x18_Save",
        Command = "App_Save",
        ScreenTippTitle = "Datensatz Speichern"
      };
    }

    public RibbonButtonDef RibbonButtonDef { get; set; }

    public RibbonButtonDef GetRibbonButtonDef()
    {
      return RibbonButtonDef;
    }
  }
}