using Help.EF;
using System;

namespace Help.Library
{
  public class ApplicationIconManager
  {
    //Handle Dark and Light Theme Icons

    private bool IsDarkTheme { get; set; }

    public ApplicationIconManager()
    {
     // var res = HelpService.GetService<SystemSettingService>().GetSystemSettingByName("IsDarkTheme").Value;
     // IsDarkTheme = Convert.ToBoolean(res);
      UpdateIcon();
    }

    //Change the Path to Setting
    public void UpdateIcon()
    {
      //if (IsDarkTheme)
      //  AppContext.WindowManagerInstance.MainWindow.Icon = AppContext.IconManagerInstance.LoadBitMapImageFromName("test");
      //else
      //  AppContext.WindowManagerInstance.MainWindow.Icon = AppContext.IconManagerInstance.LoadBitMapImageFromName("test");
    }
  }
}