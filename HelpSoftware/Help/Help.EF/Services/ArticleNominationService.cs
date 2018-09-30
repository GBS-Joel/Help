using System.Collections.Generic;
using System.Linq;

namespace Help.EF
{
  public class ArticleNominationService : HelpBaseService<ArticleNomination>
  {
    public override List<ArticleNomination> GetAllEntities()
    {
      var qry = from a in HelpContext.Instance.ArticleNominations
                select a;
      return qry.ToList();
    }

    public override ArticleNomination GetEntityByID(int id)
    {
      var qry = from a in HelpContext.Instance.ArticleNominations
                where a.ID_ArticleNomination == id
                select a;
      return qry.FirstOrDefault();
    }
  }
}