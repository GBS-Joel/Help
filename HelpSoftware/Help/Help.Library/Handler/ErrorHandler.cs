using System;
using System.Windows;

namespace Help.Library
{
  public class ErrorHandler
  {
    public void HandleError(Exception x)
    {
      if (AppContext.Logger != null)
      {
        AppContext.Logger.Error(x.Message, x.StackTrace);
      }
      ShowErrorMessage("Error in App", x.Message, x.StackTrace);
    }

    public void ShowErrorMessage(string title, string message, string stacktrace)
    {
      if (AppContext.IsAtRuntime)
      {
        ErrorMessageBox box = new ErrorMessageBox(title, message, stacktrace);
        box.ShowDialog();
      }
    }

    public void ShowErrorMessageBox(string title, string message, string stacktrace)
    {
      MessageBox.Show(message + Environment.NewLine + stacktrace, title, MessageBoxButton.OK);
    }
  }
}