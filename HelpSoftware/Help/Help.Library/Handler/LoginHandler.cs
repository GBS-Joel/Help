using Help.EF;
using System;
using System.Collections.Generic;

namespace Help.Library
{
  public class LoginHandler
  {
    public LoginHandler()
    {
      AppContext.Logger.Debug("Start Login Handler");
      if (HelpContext.IsInitialized)
      {

        AppContext.Logger.Debug("Login Handler is now Initialized");
      }
    }

    //TODO What if Context is not init yet? 
    private void WriteLoginHistory(User ConnectedUser, LoginType Type)
    {
      AppContext.Logger.Debug("Create Login History");
      LoginHistory history = new LoginHistory()
      {
        LoggedInTime = DateTime.Now,
        LoggedInUser = ConnectedUser,
        LoginType = (int)Type
      };
      HelpContext.Instance?.LoginHistorys?.Add(history);
      HelpContext.Instance.Save();
      AppContext.Logger.Debug("Login History Saved");
    }

    private bool TryAutomaticLogin()
    {
      AppContext.Logger.Debug("Try Automatic Login");
      try
      {
        //TODO: Not System Setting use Roaming Path as in Light
        string SystemPath = HelpService.GetService<SystemSettingService>().GetSystemSettingByName("DefaultLoginFilePath")?.Value;
        if (AppContext.FileHandlerInstance.CheckIfFileExits(SystemPath))
        {
          AppContext.Logger.Debug("Conf File Found Now try Auto Login");
          return TryPerformLogin(ReadConfigFile(SystemPath));
        }
        else
        {
          AppContext.Logger.Debug("Conf File Does not Exist");
          return false;
        }
      }
      catch (Exception x)
      {
        AppContext.Logger.Warn("Automatic Login Failed", x.Message);
        return false;
      }
    }

    public void AutomaticLogin()
    {
      if (TryAutomaticLogin())
      {
        AppContext.Logger.Debug("Auto Login Success Now Perform After Login Items");
        PerformAfterSuccessLogin(LoginType.AutomaticAtStartUpWithConfigFile);
      }
    }

    private void PerformAfterSuccessLogin(LoginType Type)
    {
      AppContext.IsLoggedIn = true;
      WriteLoginHistory(AppContext.LoggedInUser, Type);
      AppContext.HelpSettingsHandler.UserSettingsHandler.ValidateUserSettings(AppContext.LoggedInUser);
    }

    private Dictionary<string, string> ReadConfigFile(string ConfPath)
    {
      AppContext.Logger.Debug("Read Config File");
      string[ ] res = AppContext.FileHandlerInstance.GetContentOfFile(ConfPath);
      string Username = "";
      string Password = "";
      for (int i = 0; i < res.Length; i++)
      {
        if (res[ i ] == "Username")
        {
          Username = res[ i + 1 ];
        }
        else if (res[ i ] == "Password")
        {
          Password = res[ i + 1 ];
        }
      }
      Dictionary<string, string> Result = new Dictionary<string, string>();
      Result.Add("Username", Username);
      Result.Add("Password", Password);
      return Result;
    }

    private bool TryPerformLogin(Dictionary<string, string> Inputs)
    {
      string Username = Inputs[ "Username" ];
      string PW = Inputs[ "Password" ];
      foreach (User item in HelpService.GetService<UserService>().GetUsersFromUserName(Username))
      {
        if (item.Password == PW)
        {
          AppContext.IsLoggedIn = true;
          AppContext.LoggedInUser = item;
          return true;
        }
      }
      AppContext.Logger.Warn("Automatic Login Failed", "The PW or Username is wrong");
      return false;
    }

    private bool TryPerformLogin(string Username, string PW)
    {
      foreach (var item in HelpService.GetService<UserService>().GetUsersFromUserName(Username))
      {
        if (HashGenerator.Verify(PW, item.Password))
        {
          AppContext.IsLoggedIn = true;
          AppContext.LoggedInUser = item;
          AppContext.WindowManagerInstance.PerformAfterLogin();

          return true;
        }
      }
      return false;
    }

    public void CreateConfFile(string Username, string Password)
    {
      string SystemPath = HelpService.GetService<SystemSettingService>().GetSystemSettingByName("DefaultLoginFilePath")?.Value;
      if (AppContext.FileHandlerInstance.CheckIfFileExits(SystemPath))
      {
        AppContext.FileHandlerInstance.DeleteFile(SystemPath);
      }
      AppContext.FileHandlerInstance.CreateFile(SystemPath);
      AppContext.FileHandlerInstance.WriteToEndOfFile(SystemPath, "Username");
      AppContext.FileHandlerInstance.WriteToEndOfFile(SystemPath, Username);
      AppContext.FileHandlerInstance.WriteToEndOfFile(SystemPath, "Password");
      AppContext.FileHandlerInstance.WriteToEndOfFile(SystemPath, Password);
    }

    public void TryLogin(string Username, string Password)
    {

      if (TryPerformLogin(Username, Password))
      {
        PerformAfterSuccessLogin(LoginType.SelfLogin);
        AppContext.WindowManagerInstance.PerformAfterLogin();
      }
      else
      {
        throw new HandlerNotInitializedException();
      }
    }
  }
}