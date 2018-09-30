using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help.EF
{
  public class ActivityActionWB : IWerteBereichDef
  {
    public WertebereichDef GetWertebereichDef()
    {
      WerteBereichValueRangeItem itemupdate = new WerteBereichValueRangeItem()
      {
        Type = WerteBereichValueRangeItemType.Exact,
        Created = DateTime.Now,
        ValueName = "Action",
        Value = "Update"
      };
      //HelpContext.Instance.WerteBereichValueRangeItems.Add(itemupdate);

      WerteBereichValueRangeItem iteminsert = new WerteBereichValueRangeItem()
      {
        Type = WerteBereichValueRangeItemType.Exact,
        Created = DateTime.Now,
        ValueName = "Action",
        Value = "Insert"
      };
      //HelpContext.Instance.WerteBereichValueRangeItems.Add(iteminsert);

      WerteBereichValueRange range = new WerteBereichValueRange
      {
        Type = WerteBereichValueRangeType.InList
      };
      range.WerteBereichValueRangeItems.Add(itemupdate);
      range.WerteBereichValueRangeItems.Add(iteminsert);
      //HelpContext.Instance.WerteBereichValueRanges.Add(range);

      WertebereichDef wertebereichDef = new WertebereichDef()
      {
        AutomaticCreated = true,
        Created = DateTime.Now,
        Name = "ActivityAction"
      };
      wertebereichDef.WerteBereichValueRanges.Add(range);
      //HelpContext.Instance.WertebereichDefs.Add(wertebereichDef);
      //HelpContext.Instance.Save();
      return wertebereichDef;
    }
  }
}