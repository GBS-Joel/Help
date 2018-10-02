using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Help.EF;

namespace Help.Library
{
  public class SystemSettingAdminEMail : WerteBereichDefBase
  {
    public override string GetName()
    {
      return "SystemSettingAdminEMail";
    }

    public override WertebereichDef GetWertebereichDef()
    {
      WertebereichDef def = new WertebereichDef()
      {
        DefaultValue = "test@test.com",
        AutomaticCreated = true,
        Name = GetName(),

      };


      WerteBereichValueRange range = new WerteBereichValueRange()
      {
        Name = GetName(),
        Type = WerteBereichValueRangeType.InList,
      };


      var item = new WerteBereichValueRangeItem()
      {
        Created = DateTime.Now,
        Type = WerteBereichValueRangeItemType.Regex,
        ValueName = "Regex Mail",
        Value = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$",
      };
      HelpContext.Instance.WerteBereichValueRangeItems.Add(item);
      range.WerteBereichValueRangeItems.Add(item);
      HelpContext.Instance.WerteBereichValueRanges.Add(range);
      def.WerteBereichValueRanges.Add(range);
      return def;
    }
  }
}