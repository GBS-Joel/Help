using System;

namespace Help.EF
{
  public static class EFLogger
  {
    public static Action<string> EFLoggerMethod { get; set; }

    public static void EFLog(string Message) => EFLoggerMethod?.Invoke(Message);
  }
}