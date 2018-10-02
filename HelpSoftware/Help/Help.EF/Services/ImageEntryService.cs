using System.Collections.Generic;
using System.Linq;

namespace Help.EF
{
  class ImageEntryService : HelpBaseService<ImageEntry>
  {
    public override List<ImageEntry> GetAllEntities()
    {
      var qry = from i in HelpContext.Instance.ImageEntries
                select i;
      return qry.ToList();
    }

    public override ImageEntry GetEntityByID(int id)
    {
      var qry = from i in HelpContext.Instance.ImageEntries
                where i.ID_ImageEntry == id
                select i;
      return qry.FirstOrDefault();
    }
  }
}