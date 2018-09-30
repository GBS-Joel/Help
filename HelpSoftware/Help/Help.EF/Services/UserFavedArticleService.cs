using System.Collections.Generic;
using System.Linq;

namespace Help.EF
{
  public class UserFavedArticleService : HelpBaseService<UserFavedArticles>
  {
    public UserFavedArticleService()
    {

    }

    public override List<UserFavedArticles> GetAllEntities()
    {
      throw new System.NotImplementedException();
    }

    public override UserFavedArticles GetEntityByID(int id)
    {
      throw new System.NotImplementedException();
    }

    public bool GetIfUserFavedArticle(int ID_Article, int ID_User)
    {
      var qry = from use in HelpContext.Instance.UserFavedArticles
                where use.FavedUser.ID_User == ID_User
                where use.FavedArticle.ID_Article == ID_Article
                select use;
      if (qry.FirstOrDefault() != null)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public UserFavedArticles GetUserFavedArticle(int ID_Article, int ID_User)
    {
      var qry = from use in HelpContext.Instance.UserFavedArticles
                where use.FavedUser.ID_User == ID_User
                where use.FavedArticle.ID_Article == ID_Article
                select use;
      return qry.FirstOrDefault();
    }    
  }
}