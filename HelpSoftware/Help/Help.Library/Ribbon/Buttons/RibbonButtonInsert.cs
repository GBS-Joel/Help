using Help.EF;

namespace Help.Library
{
  public class RibbonButtonInsert : IRibbonButtonDef
  {
    public RibbonButtonDef RibbonButtonDef { get; set; }

    public RibbonButtonInsert()
    {
      RibbonButtonDef = new RibbonButtonDef()
      {
        DisplayName = "Einfügen",
        Name = "RibbonButtonInsert",
        UID = "RibbonButtonInsert",
        KeyTip = "A",
        //FontWeight = FontVariants.Normal;
        ScreenTippTitle = "Datensatz Einfügen"
      };
    }

    public RibbonButtonDef GetRibbonButtonDef()
    {
      return RibbonButtonDef;
    }
  }
}