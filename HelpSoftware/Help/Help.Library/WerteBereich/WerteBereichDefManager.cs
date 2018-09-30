using Help.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.Library
{
  public class WerteBereichDefManager
  {
    public WerteBereichDefManager()
    {
      PreLoadWerteBereichDefs();
    }

    private void PreLoadWerteBereichDefs()
    {
      var qry = from a in HelpContext.Instance.WertebereichDefs
                select a;
    }

    public WertebereichDef GetWertebereichDef(string Name)
    {
      AppContext.Logger.Debug("Getting WerteBereichDef For Name: " + Name);
      if (!string.IsNullOrEmpty(Name))
      {
        try
        {
          var qry = from w in HelpContext.Instance.WertebereichDefs
                    where w.Name == Name
                    select w;
          WertebereichDef def = qry.FirstOrDefault();
          HelpContext.Instance.Entry(def).Reload();
          return def;
        }
        catch (Exception)
        {
          throw new WerteBereichDefinitionNotFoundException(Name);
        }
      }
      else
      {
        throw new WerteBereichDefinitionNotFoundException("No Name");
      }
    }
  }
}