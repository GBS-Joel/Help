using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shell;

namespace Help
{
  public class Client
  {
    public Client()
    {

    }

    public void InitClient()
    {
      HelpContext.InitInstance();
      SettingsHandler.InitInstance();
      NoteHelper.InitInstance();
      MailHandler.InitInstance();
      MainWindow window = new MainWindow();
      window.ShowInTaskbar = true;

      JumpTask task = new JumpTask()
      {
        Title = "Create A New Article",
      };

      JumpList jumpList = new JumpList();
      jumpList.JumpItems.Add(task);
      jumpList.ShowFrequentCategory = false;
      jumpList.ShowRecentCategory = false;

      JumpList.SetJumpList(Application.Current, jumpList);

      Application.Current.MainWindow = window;
      window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
      window.WindowState = WindowState.Maximized;
      if (TryLoadConfigFile())
      {
        window.PerfomAfterLogin();
      }
      window.Show();
    }

    private bool TryLoadConfigFile()
    {
      try
      {
        string envpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string path = Path.Combine(envpath, @"Help\ConfFile.txt");
        string[ ] a = File.ReadAllLines(path);

        string Username = "";
        string Password = "";
        for (int i = 0; i < a.Length; i++)
        {
          if (a[ i ] == "Username")
          {
            Username = a[ ++i ];
          }
          else if (a[ i ] == "Password")
          {
            Password = a[ ++i ];
          }
        }
        return TryPerformLogin(Username, Password);
      }
      catch (Exception)
      {
        return false;
      }
    }

    public bool TryPerformLogin(string Username, string PW)
    {
      var qry = from u in HelpContext.Instance.Users
                where u.Username == Username
                select u;
      foreach (var item in qry.ToList())
      {
        if (item.Password == PW)
        {
          AppContext.IsLoggedIn = true;
          AppContext.LoggedInUser = item;
          return true;
        }
      }
      return false;
    }
  }
}