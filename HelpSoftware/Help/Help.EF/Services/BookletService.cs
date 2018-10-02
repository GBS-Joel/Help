using System.Collections.Generic;
using System.Linq;

namespace Help.EF
{
  public class BookletService : HelpBaseService<Booklet>
  {
    public override List<Booklet> GetAllEntities()
    {
      var qry = from b in HelpContext.Instance.Booklets
                select b;
      return qry.ToList();
    }

    public override Booklet GetEntityByID(int id)
    {
      var qry = from b in HelpContext.Instance.Booklets
                where b.ID_Booklet == id
                select b;
      return qry.FirstOrDefault();
    }
  }
}