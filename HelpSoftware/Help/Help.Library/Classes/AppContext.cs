using Help.EF;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Windows;

namespace Help.Library
{
  public static class AppContext
  {
    public static void InitAppContext()
    {
      SetClientInfo();
      CheckForDevMode();
      FileHandlerInstance = new FileHandler();
      MailHandler.InitInstance();
      OpenConnectionHandler = new OpenConnectionHandler();
      ErrorHandlerInstance = new ErrorHandler();
      BugReportHelperInstance = new BugReportHelper();
      TranslationManagerInstance = new TranslationManager();
      WindowManagerInstance = new WindowManager();
      LoginHandlerInstance = new LoginHandler();
      SearchHelperInstance = new SearchHelper();
      IconManagerInstance.LoadBitMapImageFromName("Black_48x48_Delete");
      WerteBereichManagerInstance = new WerteBereichManager();
      HelpSettingsHandler = new HelpSettingsHandler();
    }

    private static LinkManager _LinkManager { get; set; }

    public static LinkManager LinkManagerInstance
    {
      get
      {
        Logger.Debug("Getting LinkManager in AppContext");
        if (_LinkManager == null)
        {
          _LinkManager = new LinkManager();
        }
        return _LinkManager;
      }
    }

    private static QRCodeHandler _QRCodeHandler { get; set; }

    public static QRCodeHandler QRCodeHandlerInstance
    {
      get
      {
        Logger.Debug("Getting QRCodeHandler in AppContext");
        if (_QRCodeHandler == null)
          _QRCodeHandler = new QRCodeHandler();
        return _QRCodeHandler;
      }
    }

    public static void SetClientInfo()
    {
      ClientInfo = new ClientInfo();
    }

    private static RibbonManager _RibbonManager { get; set; }

    public static RibbonManager RibbonManagerInstance
    {
      get
      {
        Logger.Debug("Getting RibbonManager in AppContext");
        if (_RibbonManager == null)
          _RibbonManager = new RibbonManager();
        return _RibbonManager;
      }
    }

    public static User LoggedInUser { get; set; }

    public static bool IsLoggedIn { get; set; }

    private static bool? _isAtRuntime;

    public static bool IsAtRuntime
    {
      get
      {
        if (!_isAtRuntime.HasValue)
          _isAtRuntime = ConfigurationManager.AppSettings[ "Runtime" ] != null;

        return _isAtRuntime.Value;
      }
    }

    public static bool IsDebugModeEnabled { get; set; }

    public static bool IsDevelopement { get; set; }

    public static bool InDesignMode
    {
      get => DesignerProperties.GetIsInDesignMode(new DependencyObject());
    }

    public static WindowManager WindowManagerInstance { get; set; }

    private static HelpLogger _Logger { get; set; }

    public static HelpLogger Logger
    {
      get
      {
        if (_Logger == null)
        {
          _Logger = new HelpLogger();
        }
        return _Logger;
      }
    }

    public static FileHandler FileHandlerInstance { get; set; }

    public static OpenConnectionHandler OpenConnectionHandler { get; set; }

    public static ErrorHandler ErrorHandlerInstance { get; set; }

    public static List<IHelpHandler> RegisteredHandler { get; set; }

    public static LoginHandler LoginHandlerInstance { get; set; }

    public static void UpdateAppContextAfterDatabaseInitialiatation()
    {
      if (ClientInfo != null)
      {
        ClientInfo.DatabaseName = HelpContext.Instance.Database.Connection.Database;
      }
      else
      {
        ClientInfo = new ClientInfo()
        {
          DatabaseName = HelpContext.Instance.Database.Connection.Database
        };
      }
    }

    private static void CheckForDevMode()
    {
      Logger.Debug("Check For Dev Mode");
      if (HelpService.GetService<SystemSettingService>().GetSystemSettingByName("IsDevelopement")?.Value == "1")
      {
        IsDevelopement = true;
        Logger.Info("Developement Mode Found");
      }
      if (HelpService.GetService<SystemSettingService>().GetSystemSettingByName("IsDebugModeEnabled")?.Value == "1")
      {
        IsDebugModeEnabled = true;
        Logger.Info("IsDebugModeEnabled True");
      }
    }

    public static PermissionHandler PermissionHandlerInstance
    {
      get
      {
        Logger.Debug("Getting PermissionHandler in AppContext");
        if (_PermissionHandler == null)
          _PermissionHandler = new PermissionHandler();
        return _PermissionHandler;
      }
    }

    public static PermissionHandler _PermissionHandler { get; set; }

    public static MailHandler MailHandlerInstance { get; set; }

    public static BugReportHelper BugReportHelperInstance { get; set; }

    public static SearchHelper SearchHelperInstance { get; set; }

    public static ClientInfo ClientInfo { get; set; }

    public static WerteBereichManager WerteBereichManagerInstance
    {
      get
      {
        Logger.Debug("Getting WerteBereichManager in AppContext");
        if (_WerteBereichManager == null)
          _WerteBereichManager = new WerteBereichManager();
        return _WerteBereichManager;
      }
      set
      {
        _WerteBereichManager = value;
      }
    }

    public static WerteBereichManager _WerteBereichManager { get; set; }

    public static TranslationManager TranslationManagerInstance { get; set; }

    public static IconManager _IconManager { get; set; }

    public static IconManager IconManagerInstance
    {
      get
      {
        Logger.Debug("Getting IconManager from AppContext");
        if (_IconManager == null)
          _IconManager = new IconManager();
        return _IconManager;
      }
    }

    public static ModuleManager _ModuleManager { get; set; }

    public static ModuleManager ModuleManagerInstance
    {
      get
      {
        Logger.Debug("Getting ModuleManager from AppContext");
        if (_ModuleManager == null)
          _ModuleManager = new ModuleManager();
        return _ModuleManager;
      }
    }

    private static SaveManager _SaveManager { get; set; }

    public static SaveManager SaveManagerInstance
    {
      get
      {
        if (_SaveManager == null)
          _SaveManager = new SaveManager();
        return _SaveManager;
      }
    }

    public static IRefreshAfterLogin MainWindow { get; set; }

    public static HelpSettingsHandler HelpSettingsHandler { get; set; }
  }
}