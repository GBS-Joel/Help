using Help.EF;
using System;
using System.Collections.Generic;

namespace Help.Library
{
  public class SystemSettingsInstallDir : WerteBereichDefBase
  {
    public override string GetName()
    {
      return "SystemSettingsInstallDir";
    }

    public override WertebereichDef GetWertebereichDef()
    {
      WertebereichDef def = new WertebereichDef()
      {
        AutomaticCreated = true,
        Created = DateTime.Now,
        DefaultValue = @"C:\Help\Log",
        WerteBereichValueRanges = GetWerteBereichValueRanges(),
        Name = GetName()
      };
      foreach (var item in GetWerteBereichValueRanges())
      {
        def.WerteBereichValueRanges.Add(item);
      }
      return def;
    }

    public List<WerteBereichValueRange> GetWerteBereichValueRanges()
    {
      List<WerteBereichValueRange> range = new List<WerteBereichValueRange>();
      WerteBereichValueRange wrange = new WerteBereichValueRange()
      {
        Type = WerteBereichValueRangeType.InList,
        Name = GetName() + "Path",
      };

      WerteBereichValueRangeItem item = new WerteBereichValueRangeItem()
      {
        Created = DateTime.Now,
        Type = WerteBereichValueRangeItemType.IsPath,
        Value = @"C:\Help\Log",
        ValueName = "ExamplePath"
      };
      HelpContext.Instance.WerteBereichValueRangeItems.Add(item);
      wrange.WerteBereichValueRangeItems.Add(item);
      HelpContext.Instance.WerteBereichValueRanges.Add(wrange);
      range.Add(wrange);
      return range;
    }
  }
}