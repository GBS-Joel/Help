using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.EF
{
  public class ArticleTagService : HelpBaseService<ArticleTag>
  {
    public override List<ArticleTag> GetAllEntities()
    {
      var qry = from a in HelpContext.Instance.ArticleTags
                select a;
      return qry.ToList();
    }

    public override ArticleTag GetEntityByID(int id)
    {
      throw new NotImplementedException();
    }
  }
}