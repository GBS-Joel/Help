using Help.EF;
using System;
using System.Configuration;

namespace Help.Library
{
  public class ClientInfo
  {
    public ClientInfo()
    {
      ConnectionString = Connection.ConnectionString;
      ExecutionPath = Environment.CurrentDirectory;
      StartupInfos = Environment.CommandLine;
      OperatingSystem = Environment.OSVersion;
      UserName = Environment.UserName;
      CurrentManagedThreadId = Environment.CurrentManagedThreadId;
    }

    private static bool? _isAtRuntime;

    public static bool IsAtRuntime
    {
      get
      {
        if (!_isAtRuntime.HasValue)
          _isAtRuntime = ConfigurationManager.AppSettings["Runtime"] != null;

        return _isAtRuntime.Value;
      }
    }

    public string ExecutionPath { get; set; }

    public string StartupInfos { get; set; }

    public string ConnectionString { get; set; }

    public string DatabaseName { get; set; }

    public OperatingSystem OperatingSystem { get; set; }

    public string UserName { get; set; }

    public int CurrentManagedThreadId { get; set; }

    public string ServerVersion { get; set; }

    public string GetExtraInfo()
    {
      return "ExecutionPath: " + ExecutionPath + " StartupInfos: " + StartupInfos + " ConnectionString: " + ConnectionString +
        " Database: " + DatabaseName + " UserName " + UserName + " CurrentManagedThreadId" + CurrentManagedThreadId +
        " ServerVersion: " + ServerVersion;
    }
  }
}