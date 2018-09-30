using Help.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Help.Library
{
  //Make an interface
  public class RibbonTabStart
  {
    private RibbonTabPageDef RibbonTabPageDef { get; set; }

    public RibbonTabStart()
    {
      RibbonTabPageDef = new RibbonTabPageDef()
      {
        TabHeader = "Start",
        RequiredPermission = 0, //No Permission Required
        Name = "RibbonTabStart",
        GroupBoxes = new List<RibbonGroupBoxDef>()
      };
      LoadGroupBoxes();
    }

    public RibbonTabPageDef GetRibbonTabPageDef()
    {
      return RibbonTabPageDef;
    }

    private void LoadGroupBoxes()
    {
      RibbonTabPageDef.GroupBoxes.Add(LoadReferencedGroupBoxes("RibbonGroupBoxDatensatz"));
    }

    private RibbonGroupBoxDef LoadReferencedGroupBoxes(string Name)
    {
      var qry = from g in HelpContext.Instance.RibbonGroupBoxDefs
                where g.Name == Name
                select g;
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