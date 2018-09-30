using Help.EF;

namespace Help.Library
{
  public class RibbonButtonCopyID : IRibbonButtonDef
  {
    public RibbonButtonDef RibbonButtonDef { get; set; }

    public RibbonButtonCopyID()
    {
      RibbonButtonDef = new RibbonButtonDef()
      {
        DisplayName = "ID Kopieren",
        Name = "RibbonButtonCopyID",
        UID = "RibbonButtonCopyID",
        KeyTip = "I",
        //FontWeight = FontVariants.Normal;
        ScreenTippTitle = "ID Kopieren"
      };
    }

    public RibbonButtonDef GetRibbonButtonDef()
    {
      return RibbonButtonDef;
    }
  }
}