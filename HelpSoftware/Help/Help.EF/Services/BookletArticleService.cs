using System.Collections.Generic;
using System.Linq;

namespace Help.EF
{
  public class BookletArticleService : HelpBaseService<BookletArticle>
  {
    public override List<BookletArticle> GetAllEntities()
    {
      var qry = from b in HelpContext.Instance.BookletArticles
                select b;
      return qry.ToList();
    }

    public override BookletArticle GetEntityByID(int id)
    {
      var qry = from b in HelpContext.Instance.BookletArticles
                where b.ID_BookletArticle == id
                select b;
      return qry.FirstOrDefault();
    }
  }
}