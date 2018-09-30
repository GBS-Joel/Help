using System.Collections.Generic;
using System.Linq;

namespace Help.EF
{
  public class BackstageButtonDefService : HelpBaseService<BackstageButtonDef>
  {
    public override List<BackstageButtonDef> GetAllEntities()
    {
      var qry = from b in HelpContext.Instance.BackstageButtonDefs
                select b;
      return qry.ToList();
    }

    public override BackstageButtonDef GetEntityByID(int id)
    {
      var qry = from b in HelpContext.Instance.BackstageButtonDefs
                where b.ID_BackstageButtonDef == id
                select b;
      return qry.FirstOrDefault();
    }
  }
}