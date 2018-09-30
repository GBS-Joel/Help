using Help.EF;

namespace Help.Library
{
  public class RibbonButtonFirst : IRibbonButtonDef
  {
    public RibbonButtonDef RibbonButtonDef { get; set; }

    public RibbonButtonFirst()
    {
      RibbonButtonDef = new RibbonButtonDef()
      {
        DisplayName = "",
        Name = "RibbonButtonAktualisieren",
        UID = "RibbonButtonAktualisieren",
        KeyTip = "A",
        //FontWeight = FontVariants.Normal;
        ScreenTippTitle = "Datensatz Aktualisieren"
      };
    }

    public RibbonButtonDef GetRibbonButtonDef()
    {
      return RibbonButtonDef;
    }
  }
}