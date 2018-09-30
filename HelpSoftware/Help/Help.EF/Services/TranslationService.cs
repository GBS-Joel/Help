using System.Collections.Generic;
using System.Linq;

namespace Help.EF
{
  public class TranslationService : HelpBaseService<Translation>
  {
    public List<Translation> GetAllTranslationsWithMissingEnglischText()
    {
      var qry = from tran in HelpContext.Instance.Translations
                where tran.EnglischText == ""
                select tran;
      return qry.ToList();
    }

    public override List<Translation> GetAllEntities()
    {
      var qry = from t in HelpContext.Instance.Translations
                select t;
      return qry.ToList();
    }

    public override Translation GetEntityByID(int id)
    {
      var qry = from t in HelpContext.Instance.Translations
                where t.ID_Translation == id
                select t;
      return qry.FirstOrDefault();
    }
  }
}
