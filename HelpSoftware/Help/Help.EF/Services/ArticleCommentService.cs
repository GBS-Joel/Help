using System.Collections.Generic;
using System.Linq;

namespace Help.EF
{
  public class ArticleCommentService : HelpBaseService<ArticleComment>
  {
    public override List<ArticleComment> GetAllEntities()
    {
      throw new System.NotImplementedException();
    }

    public override ArticleComment GetEntityByID(int id)
    {
      throw new System.NotImplementedException();
    }

    public List<ArticleComment> LoadCommentsFromArticle(int ID_Article)
    {
      var qry = from ac in HelpContext.Instance.ArticleComments
                where ac.CommentArticle.ID_Article == ID_Article
                select ac;
      return qry.ToList();
    }
  }
}