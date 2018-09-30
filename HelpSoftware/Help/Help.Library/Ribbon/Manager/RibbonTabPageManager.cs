using Help.EF;
using System.Collections.Generic;
using System.Linq;

namespace Help.Library
{
  public class RibbonTabPageManager
  {
    public bool IsInitialized { get; set; }

    public RibbonTabPageManager()
    {
      CheckIfDefaultTabDefinitionExist();
      IsInitialized = true;
    }

    private void CheckIfDefaultTabDefinitionExist()
    {
      CreateDefaultTabPage(new RibbonTabStart().GetRibbonTabPageDef());
    }

    private void CreateDefaultTabPage(RibbonTabPageDef Def)
    {
      if (!CheckIfTabDefinitionIsInDB(Def))
        SaveNewTabDefinitionDef(Def);
    }

    private void SaveNewTabDefinitionDef(RibbonTabPageDef Def)
    {
      HelpContext.Instance.RibbonTabPageDefs.Add((RibbonTabPageDef)Def);
      HelpContext.Instance.SaveChanges();
    }

    private bool CheckIfTabDefinitionIsInDB(RibbonTabPageDef Def)
    {
      var qry = from b in HelpContext.Instance.RibbonTabPageDefs
                where b.Name == Def.Name
                select b;
      if (qry.FirstOrDefault() != null)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public List<RibbonTabPageDef> GetRibbonTabPageDefs()
    {
      var qry = from rt in HelpContext.Instance.RibbonTabPageDefs
                select rt;
      return qry.ToList();
    }
  }
}