using Help.EF;
using System;
using System.Linq;

namespace Help.Library
{
  public class RibbonTagDefinition
  {
    public RibbonTabPageDef RibbonTabPageDef { get; set; }

    public RibbonTabPageDef LoadTabPageDefFromDBWithName(string Name)
    {
      var qry = from t in HelpContext.Instance.RibbonTabPageDefs
                where t.Name == Name
                select t;
      if (qry.FirstOrDefault() != null)
      {
        return qry.FirstOrDefault();
      }
      else
      {
        throw new Exception();
      }
    }
  }
}