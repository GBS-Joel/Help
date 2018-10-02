using System.Linq;
using System.Collections.Generic;

namespace Help.EF
{
  public class DashBoardService : HelpBaseService<DashBoard>
  {
    public override List<DashBoard> GetAllEntities()
    {
      var qry = from d in HelpContext.Instance.DashBoards
                select d;
      return qry.ToList();
    }

    public override DashBoard GetEntityByID(int id)
    {
      var qry = from d in HelpContext.Instance.DashBoards
                where d.ID_DashBoard == id
                select d;
      return qry.FirstOrDefault();
    }
  }
}