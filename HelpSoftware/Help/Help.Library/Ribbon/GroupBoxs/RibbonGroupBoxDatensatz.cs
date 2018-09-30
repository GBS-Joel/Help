using Help.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Help.Library
{
  public class RibbonGroupBoxDatensatz
  {
    public RibbonGroupBoxDef RibbonGroupBoxDef { get; set; }

    public RibbonGroupBoxDatensatz()
    {
      RibbonGroupBoxDef = new RibbonGroupBoxDef()
      {
        Name = "RibbonGroupBoxDatensatz",
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
      //RibbonGroupBoxDef.RibbonButtonDefs.Add(LoadReferencedButton("RibbonButtonNeu"));
      //RibbonGroupBoxDef.RibbonButtonDefs.Add(LoadReferencedButton("RibbonButtonAktualisieren"));
      //RibbonGroupBoxDef.RibbonButtonDefs.Add(LoadReferencedButton("RibbonButtonChanges"));
      //RibbonGroupBoxDef.RibbonButtonDefs.Add(LoadReferencedButton("RibbonButtonSave"));
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