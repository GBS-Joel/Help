using System;
using Help.EF;
using System.Linq;
using Help.Library;
using System.Collections.Generic;
using System.ComponentModel;

namespace Help
{
  public class StartUpWindowModel
  {
    public IModuleElement Owner { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

    public int GetID()
    {
      throw new System.NotImplementedException();
    }

    public void LaodData()
    {
      LoadMostViewdArticleOfYesterday();
    }

    private void LoadMostViewdArticleOfYesterday()
    {
      var qry = from a in HelpContext.Instance.ArticleViewHistories
                where a.ViewTime == DateTime.Now.AddDays(-1)
                select a;
      List<Article> Articles = new List<Article>();
      var res = qry.ToList();
      var grouped = res.GroupBy(x => x.Article.ID_Article).OrderByDescending(x => x.Count());
    }

    public void LoadData()
    {
      throw new System.NotImplementedException();
    }

    public void ReloadAndDumpCurrentChanged()
    {
      throw new System.NotImplementedException();
    }

    public void ReloadData()
    {
    }

    public void NotifyChanged()
    {
      throw new NotImplementedException();
    }

    public void Save()
    {
      throw new NotImplementedException();
    }
  }
}