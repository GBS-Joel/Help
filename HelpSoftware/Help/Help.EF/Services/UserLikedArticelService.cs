using System.Collections.Generic;
using System.Linq;

namespace Help.EF
{
  public class UserLikedArticelService : HelpBaseService<UserLikedArticel>
  {
    public bool CheckIfUserHasLikedArticle(int ID_User, int ID_Article)
    {
      var qry = from like in HelpContext.Instance.UserLikedArticels
                where like.LikedUser.ID_User == ID_User
                where like.LikedArticel.ID_Article == ID_Article
                select like;
      if (qry.FirstOrDefault() != null)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public override List<UserLikedArticel> GetAllEntities()
    {
      var qry = from u in HelpContext.Instance.UserLikedArticels
                select u;
      return qry.ToList();
    }

    public override UserLikedArticel GetEntityByID(int id)
    {
      var qry = from u in HelpContext.Instance.UserLikedArticels
                where u.ID_UserLikedArticel == id
                select u;
      return qry.FirstOrDefault();
    }
  }
}