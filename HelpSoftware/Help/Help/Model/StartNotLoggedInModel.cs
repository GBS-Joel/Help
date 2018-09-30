using Help.EF;
using Help.Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Help
{
  public class StartNotLoggedInModel : BaseModel<StartNotLoggedInModel>
  {
    public StartNotLoggedInModel()
    {
      ModelInstance = this;
    }

    public Article Article1 { get; set; }

    public Article Article2 { get; set; }

    public Article Article3 { get; set; }

    public int CountArticleYesterday { get; set; }

    public int CountArticleMonth { get; set; }

    public int CountArticleYear { get; set; }

    public override IModuleElement Owner { get; set; }

    public StartNotLoggedInModel ModelInstance { get; set; }

    public List<Topic> Topics { get; set; }

    public List<Tag> Tags { get; set; }

    public override int GetID()
    {
      return 0;
    }

    public override void LoadData()
    {
      base.LoadData();
      LoadMostViewdArticleOfYesterday();
      LoadArticleStats();
      LoadTopicsAndTags();
    }

    public void LoadTopicsAndTags()
    {
      var qry = from t in HelpContext.Instance.Topics
                select t;
      Topics = qry.ToList();

      var qry2 = from l in HelpContext.Instance.Tags
                 select l;
      Tags = qry2.ToList();
    }

    public void LoadArticleStats()
    {
      LoadCountArticlesYesterday();
      LoadCountArticlesMonth();
      LoadCountArticlcesYear();
    }

    public void LoadCountArticlesYesterday()
    {
      var service = HelpService.GetService<ArticleService>();
      CountArticleYesterday = service.GetAllArticlesOfYesterday().Count;
    }

    public void LoadCountArticlesMonth()
    {
      var service = HelpService.GetService<ArticleService>();
      CountArticleMonth = service.GetAllArticlesOfThisMonth().Count;
    }

    public void LoadCountArticlcesYear()
    {
      var service = HelpService.GetService<ArticleService>();
      CountArticleYear = service.GetAllArticlesOfThisYear().Count;
    }

    public override void ReloadData()
    {
      LoadData();
      base.ReloadData();
    }

    private void LoadMostViewdArticleOfYesterday()
    {
      DateTime CalculatedTime = DateTime.Now.AddDays(-1);
      var qry = from a in HelpContext.Instance.ArticleViewHistories
                select a;
      List<ArticleViewHistory> Articles = new List<ArticleViewHistory>();
      foreach (var item in qry.ToList())
      {
        if (item.ViewTime.AddDays(1).Day == DateTime.Now.Day && item.ViewTime.Month == DateTime.Now.Month && item.ViewTime.Year == DateTime.Now.Year)
        {
          Articles.Add(item);
        }
      }
      if (Articles.Count != 0)
      {
        var grouped = Articles.GroupBy(x => x.Article.ID_Article).OrderByDescending(x => x.Key).Take(3);
        Article1 = grouped.ElementAt(0).First().Article;
        Article2 = grouped.ElementAt(1).First().Article;
        Article3 = grouped.ElementAt(2).First().Article;
      }
      var qry1 = from a in HelpContext.Instance.Articles
                 select a;
      Article1 = qry1.ToList().First();
      Article2 = qry1.ToList()[ 1 ];
      Article3 = qry1.ToList()[ 2 ];
      //Article1 = new Article() { ArticleTitle = "There are not Articles", ArticleText = "There are no Articles" };
      //Article2 = new Article() { ArticleTitle = "There are not Articles", ArticleText = "There are no Articles" };
      //Article3 = new Article() { ArticleTitle = "There are not Articles", ArticleText = "There are no Articles" };
    }
  }
}