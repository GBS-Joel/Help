using System.Linq;
using System;
using System.Collections.Generic;

namespace Help.EF
{
  public class ArticleService : HelpBaseService<Article>
  {
    public ArticleService()
    {

    }

    public override void UpdateCount()
    {

    }

    public List<Article> GetAllArticlesOfYesterday()
    {
      var qry = from a in HelpContext.Instance.Articles
                select a;
      return qry.ToList().Where(x => x.Created.Value.Date == DateTime.Now.Date.AddDays(-1)).ToList();
    }

    public List<Article> GetAllArticlesOfThisMonth()
    {
      var qry = from a in HelpContext.Instance.Articles
                select a;
      return qry.ToList().Where(x => x.Created.Value.Date.Month == DateTime.Now.Date.Month && x.Created.Value.Date.Year == DateTime.Now.Year).ToList();
    }

    public List<Article> GetAllArticlesOfThisYear()
    {
      var qry = from a in HelpContext.Instance.Articles
                select a;
      return qry.ToList().Where(x => x.Created.Value.Date.Year == DateTime.Now.Date.Year).ToList();
    }

    public override List<Article> GetAllEntities()
    {
      var qry = from a in HelpContext.Instance.Articles
                select a;
      return qry.ToList();
    }

    public override Article GetEntityByID(int id)
    {
      var qry = from a in HelpContext.Instance.Articles
                where a.ID_Article == id
                select a;
      return qry.First();
    }
  }
}