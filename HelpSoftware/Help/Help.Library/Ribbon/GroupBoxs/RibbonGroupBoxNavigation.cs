using Help.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Help.Library
{
  public class RibbonGroupBoxNavigation
  {
    public RibbonGroupBoxDef RibbonGroupBoxDef { get; set; }

    public RibbonGroupBoxNavigation()
    {
      RibbonGroupBoxDef = new RibbonGroupBoxDef()
      {
        Name = "RibbonGroupBoxNavigation",
        RibbonButtonDefs = new List<RibbonButtonDef>(),
      };
      LoadButtonForGroupBox();
    }

    public RibbonGroupBoxDef GetRibbonGroupBoxDef()
    {
      return RibbonGroupBoxDef;
    }

    private void LoadButtonForGroupBox()
    {
      //Buttons
      //Neu -> RibbonButtonNeu
      //Suchen
      //Löschen
    }

    private RibbonButtonDef LoadReferencedButton(string Name)
    {
      var qry = from b in HelpContext.Instance.RibbonButtonDefs
                where b.Name == Name
                select b;

      if (qry.FirstOrDefault() != null)
      {
        return qry.FirstOrDefault();
      }
      else
      {
        throw new Exception();
      }
    }
  }
}