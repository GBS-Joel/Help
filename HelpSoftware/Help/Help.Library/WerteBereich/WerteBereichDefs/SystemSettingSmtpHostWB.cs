using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Help.EF;

namespace Help.Library
{
  public class SystemSettingSmtpHostWB : WerteBereichDefBase
  {
    public override string GetName()
    {
      return "SystemSettingSmtpHostWB";
    }

    public override WertebereichDef GetWertebereichDef()
    {
      throw new NotImplementedException();
    }
  }
}