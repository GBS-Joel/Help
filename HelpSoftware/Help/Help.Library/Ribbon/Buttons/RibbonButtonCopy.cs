using Help.EF;

namespace Help.Library
{
  public class RibbonButtonCopy : IRibbonButtonDef
  {
    public RibbonButtonDef RibbonButtonDef { get; set; }

    public RibbonButtonCopy()
    {
      RibbonButtonDef = new RibbonButtonDef()
      {
        DisplayName = "Kopieren",
        Name = "RibbonButtonCopy",
        UID = "RibbonButtonCopy",
        KeyTip = "C",
        //FontWeight = FontVariants.Normal;
        ScreenTippTitle = "Datensatz Kopieren"
      };
    }

    public RibbonButtonDef GetRibbonButtonDef()
    {
      return RibbonButtonDef;
    }
  }
}