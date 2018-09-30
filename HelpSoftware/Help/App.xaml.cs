using Help;
using Microsoft.Shell;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Help
{
  public partial class App : Application, ISingleInstanceApp
  {
    [STAThread]
    public static void Main()
    {
      if (SingleInstance<App>.InitializeAsFirstInstance("MainApp"))
      {
        var application = new App();
        application.Init();
        Client c = new Client();
        c.InitClient();
        application.Run();

        // Allow single instance code to perform cleanup operations
        SingleInstance<App>.Cleanup();
      }
      else
      {
        MessageBox.Show("There is allready an Instance of Help open");
      }
    }

    public void Init()
    {
      this.InitializeComponent();
    }

    #region ISingleInstanceApp Members

    public bool SignalExternalCommandLineArgs(IList<string> args)
    {
      //TODO: handle command line arguments
      return true;
    }

    #endregion

    //private void Application_Startup(object sender, StartupEventArgs e)
    //{
    //  //Dispatcher.UnhandledException += Dispatcher_UnhandledException;
    //  Client c = new Client();
    //  c.InitClient();
    //}

    private void Dispatcher_UnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
    {
      ErrorHandler.HandleError(e.Exception);
      e.Handled = true;
    }
  }
}