using System.Collections.Generic;
using System.Linq;

namespace Help.EF
{
  public class ArticleNoteService : HelpBaseService<ArticleNote>
  {
    public override List<ArticleNote> GetAllEntities()
    {
      var qry = from a in HelpContext.Instance.ArticleNotes
                select a;
      return qry.ToList();
    }

    public override ArticleNote GetEntityByID(int id)
    {
      var qry = from a in HelpContext.Instance.ArticleNotes
                where a.ID_ArticleNote == id
                select a;
      return qry.FirstOrDefault();
    }
  }
}