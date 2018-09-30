using Help.EF;
using System.Linq;

namespace Help.Library
{
  public class RibbonGroupBoxManager
  {
    public bool IsInitialized { get; set; }

    public RibbonGroupBoxManager()
    {
      CheckIfDefaultGroupBoxesExist();
      IsInitialized = true;
    }

    private void CheckIfDefaultGroupBoxesExist()
    {
      CreateDefaultGroupBox(new RibbonGroupBoxDatensatz().GetRibbonGroupBoxDef());
    }

    private void CreateDefaultGroupBox(RibbonGroupBoxDef Def)
    {
      if (!CheckIfGroupBoxIsInDB(Def))
        SaveNewGroupBoxDef(Def);
    }

    private void SaveNewGroupBoxDef(RibbonGroupBoxDef Def)
    {
      HelpContext.Instance.RibbonGroupBoxDefs.Add(Def);
      HelpContext.Instance.SaveChanges();
    }

    private bool CheckIfGroupBoxIsInDB(RibbonGroupBoxDef Def)
    {
      var qry = from b in HelpContext.Instance.RibbonGroupBoxDefs
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
  }
}