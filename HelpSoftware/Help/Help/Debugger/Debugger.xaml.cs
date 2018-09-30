using Help.EF;
using Help.Library;
using System.Windows;

namespace Help.Debugger
{
  public partial class Debugger : Window
  {
    public DebuggerController Controller { get; set; }

    public ClientInfo ClientInfo { get; set; }

    public Debugger()
    {
      InitializeComponent();
      DataContext = this;
      Controller = new DebuggerController(Output);
      Controller.WriteDebug("Init Debugger");
      ClientInfo = Controller.GetClientInfo();
      tab1.Content = new DebuggerDatabase();
      tab2.Content = new DebuggerTranslation();
      tab3.Content = new DebuggerTools();
      tab4.Content = new DebuggerInfo(Controller);
      AppContext.Logger.InjectDebugMethod(WriteDebugLine);
    }

    public void WriteDebugLine(string Message)
    {
      Controller.Output.Text += Message;
    }

    public static void Launch()
    {
      Debugger debugger = new Debugger();
      debugger.Show();
      if (!HelpContext.IsInitialized)
      {
        HelpContext.InitInstance();
      }
      HelpContext.Instance.Database.Log = s => DebuggerDatabase.LogDebug(s);
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      //TODO Reload System Settings
      //if (AppContext. SettingHandlerInstance != null)
      //{
      //  AppContext.HelpSettingsHandler.SystemSettingsHandler.Reload SettingHandlerInstance.ReloadSystemSettings();
      //}
    }
  }
}