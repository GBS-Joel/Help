using System.Collections.Generic;
using System.Linq;

namespace Help.EF
{
  public class DashBoardUserService : HelpBaseService<DashBoardUser>
  {
    public DashBoardUserService()
    {

    }

    public override List<DashBoardUser> GetAllEntities()
    {
      throw new System.NotImplementedException();
    }

    public DashBoardUser GetCurrentDashBoardConf(int ID_User, int ID_Dashboard)
    {
      var qry = from usd in HelpContext.Instance.DashBoardUsers
                where usd.User.ID_User == ID_User
                where usd.DashBoard.ID_DashBoard == ID_Dashboard
                select usd;
      return qry.FirstOrDefault();
    }

    public override DashBoardUser GetEntityByID(int id)
    {
      throw new System.NotImplementedException();
    }
  }
}