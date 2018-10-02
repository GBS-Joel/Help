using Help.EF;
using System.Collections.Generic;
using System.Linq;

namespace Help.Library
{
  public abstract class WerteBereichDefBase : IWerteBereichDef
  {
    public bool CheckIfAllreadyInDB()
    {
      var qry = from d in HelpContext.Instance.WertebereichDefs
                where d.Name == GetName()
                select d;
      return qry.Any();
    }

    public abstract string GetName();

    public abstract WertebereichDef GetWertebereichDef();

    public abstract List<WerteBereichValueRangeItem> GetWerteBereichValueRangeItems();

    public void RegisterWerteBereich()
    {
      if (CheckIfAllreadyInDB())
        AppContext.WerteBereichManagerInstance.RegisterNewWerteBereichDef(this);
    }
  }
}