using System.Collections.Generic;
using System.Linq;

namespace Help.EF
{
  public class LinkItemService : HelpBaseService<LinkItem>
  {
    public override List<LinkItem> GetAllEntities()
    {
      var qry = from l in HelpContext.Instance.LinkItems
                select l;
      return qry.ToList();
    }

    public override LinkItem GetEntityByID(int id)
    {
      var qry = from l in HelpContext.Instance.LinkItems
                where l.ID_LinkItem == id
                select l;
      return qry.FirstOrDefault();
    }
  }
}