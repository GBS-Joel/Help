using Help.EF;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Help.AI
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      HelpContext.InitInstance();

      //Preprocess The Data!
      List<ArticleLikePrediction> Predicitons = new List<ArticleLikePrediction>();

      var qry = from u in HelpContext.Instance.UserLikedArticels
                where u.LikedUser.ID_User == 3
                select u;

      List<Article> LikedArticles = new List<Article>();

      foreach (var item in qry.ToList())
      {
        var querry = from a in HelpContext.Instance.Articles
                     where a.ID_Article == item.LikedArticel.ID_Article
                     select a;
        Article art = querry.FirstOrDefault();
        LikedArticles.Add(art);
      }

      //Create the DataSource
      var data = new List<ArticleLikeData>();

      string tag1 = "";
      string tag2 = "";
      string topic1 = "";
      string topic2 = "";

      foreach (var item in LikedArticles)
      {
        if (item.Tags.Count > 0)
        {
          tag1 = item.Tags[0].TagName;
        }
        if (item.Tags.Count > 1)
        {
          tag2 = item.Tags[1].TagName;
        }
        if (item.Topics.Count > 0)
        {
          topic1 = item.Topics[0].Name;
        }
        if (item.Topics.Count > 1)
        {
          topic2 = item.Topics[1].Name;
        }

        data.Add(new ArticleLikeData()
        {
          ArticlePreview = item.ArticlePreview,
          ArticleText = item.ArticleText,
          ArticleTitle = item.ArticleTitle,
          Created = item.Created.ToString(),
          Tag1 = tag1,
          Tag2 = tag2,
          Topic1 = topic1,
          Topic2 = topic2
        });
      }

      var resdata = CollectionDataSource.Create(data);

      var pipeline = new LearningPipeline();
      pipeline.Add(resdata);
      pipeline.Add(new ColumnConcatenator(outputColumn: "Features",
        "ArticlePreview", "ArticleText", "ArticleTitle", "Tag1", "Tag2", "Topic1", "Topic2", "Created"));
      pipeline.Add(new FastTreeBinaryClassifier());

      PredictionModel<ArticleLikeData, ArticleLikePrediction> model = pipeline.Train<ArticleLikeData, ArticleLikePrediction>();

      pipeline = new LearningPipeline();

      resdata = CollectionDataSource.Create(data.AsEnumerable());
      pipeline.Add(resdata);

      //pipeline.Add(new ColumnConcatenator(outputColumn: "Features")

      Console.ReadKey();

      ////How do we load the Data?
      ////Create DAtaLoaded Classes and load the Data from those
      ////Create Data
      //var data = new List<ArticleLikePredictionData>()
      //{
      //  new ArticleLikePredictionData { LikedArticle1 = 1f, LikedArticle2 = 2f}
      //};

      //pipeline.Add(new TextLoader("ArticleData.csv").CreateFrom<ArticleLikePredictionData>(useHeader: true, separator: ','));

      //pipeline.Add(new ColumnConcatenator("Features", "LikedArticle1", "LikedArticle2"));

      //var model = pipeline.Train<ArticleLikePredictionData, ArticleLikePrediction>();

      //var testData = new TextLoader("ArticleTextData.csv").CreateFrom<ArticleLikePredictionData>(useHeader: true, separator: ',');

      //var evaluator = new RegressionEvaluator();

      //var metrics = evaluator.Evaluate(model, testData);

      //Console.WriteLine($"Root Mean Squared : {metrics.Rms}");
      //Console.WriteLine($"R^2: {metrics.RSquared}");
      //Console.ReadKey();
    }
  }

  internal class Artilcle
  {
  }
}