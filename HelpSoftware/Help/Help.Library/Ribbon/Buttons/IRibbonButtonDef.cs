using Help.EF;

namespace Help.Library
{
  internal interface IRibbonButtonDef
  {
    RibbonButtonDef RibbonButtonDef { get; set; }

    RibbonButtonDef GetRibbonButtonDef();
  }
}