using System.Collections.Generic;
using System.Linq;

namespace Help.EF
{
  public class ArticleViewHistoryService : HelpBaseService<ArticleViewHistory>
  {
    public override List<ArticleViewHistory> GetAllEntities()
    {
      var qry = from a in HelpContext.Instance.ArticleViewHistories
                select a;
      return qry.ToList();
    }

    public override ArticleViewHistory GetEntityByID(int id)
    {
      var qry = from a in HelpContext.Instance.ArticleViewHistories
                where a.ID_ArticleViewHistory == id
                select a;
      return qry.FirstOrDefault();
    }
  }
}