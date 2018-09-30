using Help.EF;
using Help.Library;
using System.Data;
using System.Linq;
using System.Windows;

namespace Help.Stats
{
  public partial class App : Application
  {
    private void Application_Startup(object sender, StartupEventArgs e)
    {
      HelpContext.InitInstance();
      var qry = from u in HelpContext.Instance.Users
                where u.ID_User == 3
                select u;
      AppContext.LoggedInUser = qry.FirstOrDefault();
      AppContext.IsLoggedIn = true;

      Application.Current.MainWindow = new MainWindow();
      Application.Current.MainWindow.Show();
    }
  }
}