using System.Collections.Generic;
using System.Linq;

namespace Help.EF
{
  public class LoginHistoryService : HelpBaseService<LoginHistory>
  {
    public override List<LoginHistory> GetAllEntities()
    {
      var qry = from l in HelpContext.Instance.LoginHistorys
                select l;
      return qry.ToList();
    }

    public override LoginHistory GetEntityByID(int id)
    {
      var qry = from l in HelpContext.Instance.LoginHistorys
                where l.ID_LoginHistory == id
                select l;
      return qry.FirstOrDefault();
    }
  }
}