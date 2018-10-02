using System.Collections.Generic;

namespace Help.Library
{
  public static class WerteBereichDefRegisterer
  {
    public static List<WerteBereichDefBase> NewWerteBereichDefs { get; set; } = new List<WerteBereichDefBase>();

    //Here must be all new Wertebereichdefs registered or else they are not in the DB!
    public static void RegisteredWerteBereichDefs()
    {
      NewWerteBereichDefs.Add(new ActivityActionWB());
      NewWerteBereichDefs.Add(new SystemSettingsInstallDir());
      NewWerteBereichDefs.Add(new SystemSettingAdminEMail());
    }

    public static void UdpateRegisteredWertebereichs()
    {
      foreach (var item in NewWerteBereichDefs)
      {
        item.RegisterWerteBereich();
      }
    }
  }
}