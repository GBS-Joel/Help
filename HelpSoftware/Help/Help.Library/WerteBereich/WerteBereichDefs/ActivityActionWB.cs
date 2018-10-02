using Help.EF;
using System;
using System.Collections.Generic;

namespace Help.Library
{
  public class ActivityActionWB : WerteBereichDefBase
  {
    public override string GetName()
    {
      return "ActivityAction";
    }

    public override WertebereichDef GetWertebereichDef()
    {
      List<WerteBereichValueRange> ranges = new List<WerteBereichValueRange>();
      WerteBereichValueRange range = new WerteBereichValueRange
      {
        Type = WerteBereichValueRangeType.InList
      };
      range.WerteBereichValueRangeItems = GetWerteBereichValueRangeItems();
      HelpContext.Instance.WerteBereichValueRanges.Add(range);
      WertebereichDef wertebereichDef = new WertebereichDef()
      {
        AutomaticCreated = true,
        Created = DateTime.Now,
        Name = GetName()
      };
      wertebereichDef.WerteBereichValueRanges.Add(range);
      HelpContext.Instance.WertebereichDefs.Add(wertebereichDef);
      HelpContext.Instance.Save();
      return wertebereichDef;
    }

    public List<WerteBereichValueRangeItem> GetWerteBereichValueRangeItems()
    {
      List<WerteBereichValueRangeItem> RangeItems = new List<WerteBereichValueRangeItem>();
      WerteBereichValueRangeItem itemupdate = new WerteBereichValueRangeItem()
      {
        Type = WerteBereichValueRangeItemType.Exact,
        Created = DateTime.Now,
        ValueName = "Action",
        Value = "Update"
      };
      RangeItems.Add(itemupdate);
      WerteBereichValueRangeItem iteminsert = new WerteBereichValueRangeItem()
      {
        Type = WerteBereichValueRangeItemType.Exact,
        Created = DateTime.Now,
        ValueName = "Action",
        Value = "Insert"
      };
      RangeItems.Add(iteminsert);
      return RangeItems;
    }
  }
}