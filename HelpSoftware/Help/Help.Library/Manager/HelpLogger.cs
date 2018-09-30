using Help.EF;
using System;
using System.Collections.Generic;

namespace Help.Library
{
  public class HelpLogger
  {
    private string LogPath { get; set; }

    private bool DefaultVerbose { get; set; }

    private Magnitude DefaultMagnitude { get; set; } = Magnitude.NaN;

    private Magnitude ActualMagnitude { get; set; } = Magnitude.NaN;

    private bool IsLoggingDisabled { get; set; }

    private Action<string> InvokeOnLog { get; set; }

    public HelpLogger()
    {
      LogItemQueue = new List<LogItem>();
      UpdateDefaultMagnitude();
      DefaultVerbose = false;
      IsInitialized = true;
      IsLoggingDisabled = false;
      EFLogger.EFLoggerMethod = LogEFService;
    }

    public void LogEFService(string Message)
    {
      LogMessage(CreateLogItem(Message, false, ""));
    }

    public void InjectDebugMethod(Action<string> ActionToCall)
    {
      if (ActionToCall != null)
        InvokeOnLog = ActionToCall;
    }

    private bool _IsInitialized { get; set; }

    private bool IsMessageQueueProcessed { get; set; } = false;

    private List<LogItem> LogItemQueue { get; set; }

    private readonly string WarnSeperator = "------------------------- Warn -------------------------" + Environment.NewLine;

    private readonly string ErrorSeperator = "######################## Error ########################" + Environment.NewLine;

    private bool IsContextLog = false;

    private string Path { get; set; }

    private bool IsInitialized
    {
      get
      {
        return _IsInitialized;
      }
      set
      {
        _IsInitialized = value;
        ProcessMessageQueueLogItem();
        UdpateActualMagnitude();
        UpdateLogPath();
        AfterUpdateMagnitude();
      }
    }

    private void UpdateLogPath()
    {
      LogPath = GetLogFilePath();
    }

    private void UdpateActualMagnitude()
    {
      if (AppContext.IsLoggedIn)
      {
        var value = HelpService.GetService<SystemSettingService>().GetSystemSettingByName("Magnitude")?.Value;
        if (value != null)
          ActualMagnitude = (Magnitude)Enum.Parse(typeof(Magnitude), value);
        else
          ActualMagnitude = Magnitude.None;
      }
      else
      {
        ActualMagnitude = Magnitude.None;
      }
      UpdateDefaultMagnitude();
    }

    private void UpdateDefaultMagnitude()
    {
      if (AppContext.IsDebugModeEnabled)
      {
        DefaultMagnitude = Magnitude.Debug;
        DefaultVerbose = true;
      }
      if (AppContext.IsDevelopement || true)
      {
        DefaultMagnitude = Magnitude.Developement;
        DefaultVerbose = true;
      }
    }

    private void AfterUpdateMagnitude()
    {
      //ActualMagnitude = Magnitude.Debug;
      if (DefaultMagnitude == Magnitude.Developement)
      {
        HelpContext.Instance.Database.Log = l => AppContext.Logger.ContextLog(l);
      }
    }

    private LogItem CreateLogItem(string Message, bool Verbosity, string ExtraInfo)
    {
      LogItem item = new LogItem();
      if (AppContext.IsLoggedIn)
      {
        item.User = AppContext.LoggedInUser;
      }
      item.Verbose = Verbosity;
      item.Time = DateTime.Now;
      item.Text = Message;
      item.Magnitude = (int)ActualMagnitude;
      if (Verbosity)
        item.ExtraInfo = ExtraInfo;
      return item;
    }

    private void ProcessMessageQueueLogItem()
    {
      foreach (var item in LogItemQueue)
      {
        LogMessage(item);
      }
      LogItemQueue.Clear();
      IsMessageQueueProcessed = true;
    }

    private void LogMessage(string Message, bool Verbose, Magnitude Magnitude)
    {
      if (Magnitude != Magnitude.NaN)
      {
        if (!IsInitialized)
        {
          LogItemQueue.Add(CreateLogItem(Message, Verbose, GetExtraInfo()));
        }
        else
        {
          if (Verbose)
          {
            LogMessage(CreateLogItem(Message, Verbose, GetExtraInfo()));
          }
          else
          {
            LogMessage(CreateLogItem(Message, Verbose, ""));
          }
        }
      }
    }

    private void AddToMessageQueue(string Message)
    {
      LogItemQueue.Add(CreateLogItem(Message, false, GetExtraInfo()));
    }

    private void AddToMessageQueue(LogItem Item)
    {
      LogItemQueue.Add(Item);
    }

    private string GetHeader(string Header)
    {
      return DateTime.Now.ToString() + "\t " + Header + ": \t";
    }

    private string GetExtraInfo()
    {
      return "";
      // return AppContext.ClientInfo.GetExtraInfo();
    }

    private void LogMessage(LogItem ItemToLog)
    {
      if (IsInitialized)
      {
        SaveLogItem(ItemToLog);
        string message = "";
        if (ItemToLog.Verbose)
        {
          message = GetHeader(ActualMagnitude.ToString()) + ItemToLog.Text + Environment.NewLine + GetExtraInfo();
        }
        else
        {
          message = GetHeader(ActualMagnitude.ToString()) + ItemToLog.Text;
        }
        SaveToFile(message);
        if (InvokeOnLog != null)
          InvokeOnLog.Invoke(message);
      }
      else
      {
        AddToMessageQueue(ItemToLog);
      }
    }

    private void SaveToFile(string Message)
    {
      if (AppContext.FileHandlerInstance != null)
        AppContext.FileHandlerInstance.WriteToEndOfFile(GetLogFilePath(), Message);
    }

    private void SaveLogItem(LogItem Item)
    {
      if (Item.Magnitude != 7)
        HelpContext.Instance.LogItems.Add(Item);
    }

    private string GetLogFilePath()
    {
      if (Path == "" || Path == null)
      {
        Path = @"C:\Help\log.txt";
        //TODO Save to System Setting and Set Default to Roaming File
        // Path = AppContext.SettingHandlerInstance?.GetSystemSettingFromName("LogFilePath")?.Value;
      }
      return Path;
    }

    public void Debug(string Message)
    {
      if (Message != null)
        if (ActualMagnitude != Magnitude.Minimum && ActualMagnitude != Magnitude.None && ActualMagnitude != Magnitude.NaN)
        {
          if (ActualMagnitude == Magnitude.Debug)
          {
            LogMessage(Message, false, ActualMagnitude);
          }
          else
          {
            LogMessage(Message, true, ActualMagnitude);
          }
        }
    }

    public void Error(string Error, string StackTrace)
    {
      string message = ErrorSeperator + Error;
      LogMessage(CreateLogItem(message, true, StackTrace));
    }

    public void Warn(string Warn, string ExtraInfo)
    {
      string message = WarnSeperator + Warn;
      LogMessage(CreateLogItem(message, true, ExtraInfo));
    }

    public void Info(string Info)
    {
      if (ActualMagnitude != Magnitude.None && ActualMagnitude != Magnitude.NaN)
      {
        if (ActualMagnitude == Magnitude.Minimum)
        {
          LogMessage(Info, false, ActualMagnitude);
        }
      }
    }

    public void ContextLog(string context)
    {
      if (!IsLoggingDisabled && context != null)
      {
        IsLoggingDisabled = true;
        if (IsContextLog)
        {
          Debug(context);
          IsContextLog = false;
        }
        else
        {
          IsContextLog = true;
        }
        IsLoggingDisabled = false;
      }
      else
      {
        HelpContext.Instance.Database.Log = null;
      }
      IsLoggingDisabled = false;
    }
  }
}