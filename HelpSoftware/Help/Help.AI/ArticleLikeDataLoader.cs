namespace Help.AI
{
  //public class ArticleLikeDataLoader : IDataLoader<ArticleLikePredictionData>
  //{
  //  //Paramter is ID of user
  //  public List<ArticleLikePredictionData> LoadDataForEvaluate(object Parameter)
  //  {
  //    List<ArticleLikePredictionData> Data = new List<ArticleLikePredictionData>();

  //    List<Article> arts = GetAllLikedArticles((int)Parameter);

  //    var currentdata = new ArticleLikePredictionData();

  //    if (arts.Count > 0 && arts[ 0 ] != null)
  //    {
  //      currentdata.LikedArticle0 = arts.ElementAt(0).ID_Article;
  //    }

  //    if (arts.Count > 1 && arts[ 1 ] != null)
  //    {
  //      currentdata.LikedArticle0 = arts.ElementAt(1).ID_Article;
  //    }

  //    if (arts.Count > 2 && arts[ 2 ] != null)
  //    {
  //      currentdata.LikedArticle0 = arts.ElementAt(2).ID_Article;
  //    }

  //    Data.Add(currentdata);

  //    return Data;
  //  }

  //  private List<Article> GetAllLikedArticles(int ID_User)
  //  {
  //    var qry = from a in HelpContext.Instance.Articles
  //              where a.Author.ID_User == ID_User
  //              where a.Stars == 1
  //              select a;
  //    return qry.ToList();
  //  }

  //  public List<ArticleLikePredictionData> LoadDataForPrediction(object Parameter)
  //  {
  //    throw new NotImplementedException();
  //  }

  //  public void StoreData()
  //  {
  //    throw new NotImplementedException();
  //  }
  //}
}