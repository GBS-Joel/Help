using Help.EF;
using Help.Library;
using System.Windows;

namespace Help
{
  public class Client
  {
    public Client()
    {
      PerformBeforeClientInit();
      CheckIfIsFirstStartUp();
      PerformClientInit();
    }

    public bool CheckIfIsFirstStartUp()
    {
      string SettingName = "FirstStartUp";
      SystemSetting setting = HelpService.GetService<SystemSettingService>().GetSystemSettingByName(SettingName);
      if (setting == null)
      {
        //TODO Refactor to Auto Create when missing System Settings
        //AppContext.HelpSettingsHandler.SystemSettingsHandler. SettingHandlerInstance.SystemSettingNotFound(SettingName);
        return false;
      }
      else
      {
        return setting.Value == "0";
      }
    }

    public void RegisterHandler()
    {
      AppContext.InitAppContext();
    }

    public void InitDatabase()
    {
      HelpContext.InitInstance();
      AppContext.UpdateAppContextAfterDatabaseInitialiatation();
      HelpContext.SaveMethod = AppContext.SaveManagerInstance.Save;
    }

    public void PerformBeforeClientInit()
    {
      InitDatabase();
      RegisterHandler();
    }

    public void PerformClientInit()
    {
      AppContext.Logger.Debug("Perfom Client Init");
      CreateNewOpenConnection();
      AppContext.IsDebugModeEnabled = true;
      AppContext.IsDevelopement = true;
      HelpWindow window = new HelpWindow();
      AppContext.WindowManagerInstance.SetMainWindow(window);
      window.ShowInTaskbar = true;
      Application.Current.MainWindow = window;
      window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
      window.WindowState = WindowState.Maximized;
      AppContext.LoginHandlerInstance.AutomaticLogin();
      window.Show();
      if (AppContext.IsLoggedIn)
      {
        window.UpdateOnLogin();
        AppContext.WindowManagerInstance.OpenNewWindow(new Main());
      }
      else
      {
        AppContext.WindowManagerInstance.OpenNewWindow(new Registrate());
      }
    }

    public void CreateNewOpenConnection()
    {
      AppContext.OpenConnectionHandler.CreateNewConnection();
    }
  }
}