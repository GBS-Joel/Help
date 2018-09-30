using Help.EF;
using System.Linq;

namespace Help.Library
{
  public class RibbonButtonManager
  {
    public bool IsInitialized { get; set; }

    public RibbonButtonManager()
    {
      CheckIfDefaultButtonExist();
      IsInitialized = true;
    }

    private void CheckIfDefaultButtonExist()
    {
      CreateDefaultButton(new RibbonButtonNeu().GetRibbonButtonDef());
    }

    private void CreateDefaultButton(RibbonButtonDef Def)
    {
      if (!CheckIfButtonIsInDB(Def))
        SaveNewButtonDef(Def);
    }

    private void SaveNewButtonDef(RibbonButtonDef Def)
    {
      HelpContext.Instance.RibbonButtonDefs.Add((RibbonButtonDef)Def);
      HelpContext.Instance.SaveChanges();
    }

    private bool CheckIfButtonIsInDB(RibbonButtonDef Def)
    {
      var qry = from b in HelpContext.Instance.RibbonButtonDefs
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