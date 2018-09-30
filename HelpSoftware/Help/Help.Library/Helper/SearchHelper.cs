using Help.EF;
using System.Collections.Generic;
using System.Linq;

namespace Help.Library
{
  public class SearchHelper
  {
    public SearchHelper()
    {
      AppContext.Logger.Debug("Init Instance SearchHelper");
    }

    public List<Article> PerformSearch(string searchtext)
    {
      AppContext.Logger.Debug("Start Search For SearchText: " + searchtext);
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
            return res.ToList();
          }
        }
        else
        {
          List<Article> res = qry.ToList();
          if (res.Count() != 0)
          {
            return res.ToList();
          }
        }
      }
      else
      {
        return new List<Article>();
      }
      return new List<Article>();
    }
  }
}