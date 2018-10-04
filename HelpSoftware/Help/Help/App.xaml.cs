using Help.EF;
using Help.Library;
using Microsoft.Shell;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace Help
{
  public partial class App : Application, ISingleInstanceApp
  {
    public bool CheckSingleInstance()
    {
      if (SingleInstance<App>.InitializeAsFirstInstance("Help"))
      {
        Dispatcher.UnhandledException += Dispatcher_UnhandledException;
        //Client c = new Client();
        //c.InitClient();
        //var application = new App();
        //application.Init();
        //application.MainWindow = Client.CurrentMainWindow;
        //application.Run(Client.CurrentMainWindow);
        //SingleInstance<App>.Cleanup();

        return true;
      }
      else
      {
        MessageBox.Show("Seccond Instance");
        return false;
      }
    }

    private void Dispatcher_UnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
    {
      AppError error = new AppError()
      {
        ErrorMessage = e.Exception.Message,
        StackTrace = e.Exception.StackTrace,
        Created = DateTime.Now
      };
      HelpContext.Instance.AppErrors.Add(error);
      HelpContext.Instance.SaveChanges();
      if (AppContext.ErrorHandlerInstance != null)
      {
        AppContext.ErrorHandlerInstance.HandleError(e.Exception);
      }
      else
      {
        AppContext.ErrorHandlerInstance = new ErrorHandler();
        AppContext.ErrorHandlerInstance.HandleError(e.Exception);
      }
      e.Handled = true;
    }

    public bool SignalExternalCommandLineArgs(IList<string> args)
    {
      return CommandLineArgumentHelper.ProcessCommandLineArgs(args);
    }

    private void Application_Startup(object sender, StartupEventArgs e)
    {
      if (CheckSingleInstance())
      {
        // AppContext.Language = AppLanguage.EN;
        Client c = new Client();
      }
      else
      {
        Environment.Exit(0);
      }
    }

    private void Application_Exit(object sender, ExitEventArgs e)
    {
      if (AppContext.OpenConnectionHandler != null)
        AppContext.OpenConnectionHandler.RemoveOpenConnection();
    }

    private void Application_Activated(object sender, EventArgs e)
    {
      if (AppContext.OpenConnectionHandler != null)
        AppContext.OpenConnectionHandler.UpdateOpenConnection();
    }

    private void Application_Deactivated(object sender, EventArgs e)
    {
      if (AppContext.OpenConnectionHandler != null)
        AppContext.OpenConnectionHandler.UpdateOpenConnection();
    }
  }
}