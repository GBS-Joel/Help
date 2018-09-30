using System.Collections.Generic;
using System.Linq;

namespace Help.EF
{
  public class ArticleProposalService : HelpBaseService<ArticleProposal>
  {
    public override List<ArticleProposal> GetAllEntities()
    {
      var qry = from a in HelpContext.Instance.ArticleProposals
                select a;
      return qry.ToList();
    }

    public override ArticleProposal GetEntityByID(int id)
    {
      var qry = from a in HelpContext.Instance.ArticleProposals
                where a.ID_ArticleProposal == id
                select a;
      return qry.FirstOrDefault();
    }
  }
}