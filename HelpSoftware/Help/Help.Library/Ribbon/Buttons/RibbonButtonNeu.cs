using Help.EF;

namespace Help.Library
{
  public class RibbonButtonNeu : IRibbonButtonDef
  {
    public RibbonButtonDef RibbonButtonDef { get; set; }

    public RibbonButtonNeu()
    {
      RibbonButtonDef = new RibbonButtonDef()
      {
        DisplayName = "Neu",
        Name = "RibbonButtonNeu",
        UID = "RibbonButtonNeu",
        KeyTip = "N",
        //FontWeight = FontVariants.Normal;
        ScreenTippTitle = "Neu Erfassen"
      };
    }

    public RibbonButtonDef GetRibbonButtonDef()
    {
      return RibbonButtonDef;
    }
  }
}