using System.Collections.Generic;
using System.Linq;

namespace Help.EF
{
  public class UserWatchArticleService : HelpBaseService<UserWatchArticle>
  {
    public UserWatchArticleService()
    {

    }

    public UserWatchArticle GetUserWatchedArticle(int ID_Article, int ID_User)
    {
      var qry = from uwa in HelpContext.Instance.UserWatchArticles
                where uwa.WatchedArticle.ID_Article == ID_Article
                where uwa.WatchedUser.ID_User == ID_User
                select uwa;
      return qry.FirstOrDefault();
    }

    public bool GetIfArticleIsWatchedFromUser(int ID_Article, int ID_User)
    {
      var qry = from uwa in HelpContext.Instance.UserWatchArticles
                where uwa.WatchedArticle.ID_Article == ID_Article
                where uwa.WatchedUser.ID_User == ID_User
                select uwa;
      if (qry.FirstOrDefault() != null)
      {
        return true;
      }
      else
      {
        return false;
      }
    }   

    public override List<UserWatchArticle> GetAllEntities()
    {
      throw new System.NotImplementedException();
    }

    public override UserWatchArticle GetEntityByID(int id)
    {
      throw new System.NotImplementedException();
    }
  }
}