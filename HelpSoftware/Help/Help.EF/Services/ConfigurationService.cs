using System.Collections.Generic;
using System.Linq;

namespace Help.EF
{
  public class ConfigurationService : HelpBaseService<Configuration>
  {
    public override List<Configuration> GetAllEntities()
    {
      var qry = from c in HelpContext.Instance.Configurations
                select c;
      return qry.ToList();
    }

    public override Configuration GetEntityByID(int id)
    {
      var qry = from c in HelpContext.Instance.Configurations
                where c.ID_Configuration == id
                select c;
      return qry.FirstOrDefault();
    }
  }
}