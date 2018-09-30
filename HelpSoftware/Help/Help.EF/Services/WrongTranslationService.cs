using System.Linq;
using System.Collections.Generic;

namespace Help.EF
{
  public class WrongTranslationService : HelpBaseService<WrongTranslation>
  {
    public WrongTranslationService()
    {

    }

    public override List<WrongTranslation> GetAllEntities()
    {
      var qry = from wt in HelpContext.Instance.WrongTranslations
                select wt;
      return qry.ToList();
    }

    public override WrongTranslation GetEntityByID(int id)
    {
      var qry = from wt in HelpContext.Instance.WrongTranslations
                where wt.ID_WrongTranslation == id
                select wt;
      return qry.FirstOrDefault();
    }
  }
}