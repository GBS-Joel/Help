using Help.EF;

namespace Help.Library
{
  public class RibbonButtonCut : IRibbonButtonDef
  {
    public RibbonButtonDef RibbonButtonDef { get; set; }

    public RibbonButtonCut()
    {
      RibbonButtonDef = new RibbonButtonDef()
      {
        DisplayName = "Ausschneiden",
        Name = "RibbonButtonCut",
        UID = "RibbonButtonCut",
        KeyTip = "X",
        //FontWeight = FontVariants.Normal;
        ScreenTippTitle = "Datensatz Ausschneiden"
      };
    }

    public RibbonButtonDef GetRibbonButtonDef()
    {
      return RibbonButtonDef;
    }
  }
}