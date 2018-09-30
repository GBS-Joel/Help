using Help.EF;

namespace Help.Library
{
  public class RibbonButtonChanges : IRibbonButtonDef
  {
    public RibbonButtonChanges()
    {
      RibbonButtonDef = new RibbonButtonDef()
      {
        DisplayName = "Änderungen",
        Name = "RibbonButtonChanges",
        UID = "RibbonButtonChanges",
        KeyTip = "C",
        //FontWeight = FontVariants.Normal;
        ScreenTippTitle = "Änderungen"
      };
    }

    public RibbonButtonDef RibbonButtonDef { get; set; }

    public RibbonButtonDef GetRibbonButtonDef()
    {
      return RibbonButtonDef;
    }
  }
}