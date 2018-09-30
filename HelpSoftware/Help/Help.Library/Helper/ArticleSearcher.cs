using Help.EF;
using System.Collections.Generic;
using System.Linq;

namespace Help.Library
{
  public static class ArticleSearcher
  {
    public static List<Article> TrySearch(string searchtext)
    {
      List<Article> SearchArticles = new List<Article>();
      if (searchtext != "")
      {
        var qry = from art in HelpContext.Instance.Articles
                  where art.ArticleTitle.Contains(searchtext)
                  select art;
        if (qry.Count() < 10)
        {
          var qryres = from art in HelpContext.Instance.Articles
                       where art.ArticleTitle.Contains(searchtext)
                       || art.ArticlePreview.Contains(searchtext)
                       select art;
          List<Article> res = qryres.ToList();
          if (res.Count() != 0)
          {
            SearchArticles = res.ToList();
          }
        }
        else
        {
          SearchArticles = qry.ToList();
        }
      }
      foreach (var item in SearchArticles)
      {
        if (item.Author != null)
        {
          item.Author.Password = null;
        }
      }
      return SearchArticles;
    }
  }
}