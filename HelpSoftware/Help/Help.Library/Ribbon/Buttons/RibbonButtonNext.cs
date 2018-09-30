using Help.EF;

namespace Help.Library
{
  public class RibbonButtonNext : IRibbonButtonDef
  {
    public RibbonButtonDef RibbonButtonDef { get; set; }

    public RibbonButtonNext()
    {
      RibbonButtonDef = new RibbonButtonDef()
      {
        DisplayName = "",
        Name = "RibbonButtonAktualisieren",
        UID = "RibbonButtonAktualisieren",
        KeyTip = "A",
        ScreenTippTitle = "Datensatz Aktualisieren"
      };
    }

    public RibbonButtonDef GetRibbonButtonDef()
    {
      return RibbonButtonDef;
    }
  }
}