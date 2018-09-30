using Help.EF;
using Help.Library;
using MahApps.Metro;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Linq;
using System.Windows;

namespace Help
{
  public partial class MainWindow : MetroWindow
  {
    public StartUpWindow window { get; set; }

    public MainWindow()
    {
      DataContext = this;
      InitializeComponent();
      PerformStartUp();
      window = new StartUpWindow();
      StartUpWindow w = new StartUpWindow();
      window = w;
      ContentP.Content = w;
      Window_Loaded();
      throw new HandlerNotInitializedException();
    }

    private void Window_Loaded()
    {
      JumpListHandler.CreateJumpList();
    }

    public void PerformStartUp()
    {
      GetRandomColor();
    }

    public void GetRandomColor()
    {
      if (!AppContext.IsLoggedIn)
      {
        GetRandomAppColor();
      }
      else
      {
        var qry = from set in HelpContext.Instance.Settings
                  where set.SettingName == "RandomAppTheme"
                  select set;
        Setting setting = qry.FirstOrDefault();
        var qry1 = from s in HelpContext.Instance.UserSettings
                   where s.Setting.ID_UserSetting == setting.ID_UserSetting
                   select s;
        UserSetting se = qry1.FirstOrDefault();
        if (se.UserValue == "1")
        {
          GetRandomAppColor();
        }
        else
        {
          Setting usetting = AppContext.HelpSettingsHandler.SettingsHandler.GetSettingFromName("Color");

          var q = from i in HelpContext.Instance.UserSettings
                  where i.Setting.ID_UserSetting == usetting.ID_UserSetting
                  select i;
          SetAppColor(Convert.ToInt32(q.FirstOrDefault().UserValue));
        }
      }
    }

    public void SetAppColor(int Color)
    {
    }

    public void GetRandomAppColor()
    {
      //  Tuple<AppTheme, Accent> theme = ThemeManager.DetectAppStyle(Application.Current);
      //  Random r = new Random();
      //  int random = r.Next(0, Enum.GetNames(typeof(ApplicationThemes)).Length - 1);
      //  var vals = Enum.GetValues(typeof(ApplicationThemes));
      //  ApplicationThemes a = (ApplicationThemes)vals.GetValue(random);
      //  ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent(a.ToString()), theme.Item1);
    }

    public void ChangeAppStyle(string Theme)
    {
      ThemeManager.ChangeAppTheme(Application.Current, Theme);
    }

    private void btnRegister_Click(object sender, RoutedEventArgs e)
    {
      AppContext.WindowManagerInstance.OpenNewWindow(new Registrate());
    }

    private async void btnLogin_Click(object sender, RoutedEventArgs e)
    {
      LoginDialogData result = await this.ShowLoginAsync("Login", "Enter your credentials", new LoginDialogSettings { ColorScheme = this.MetroDialogOptions.ColorScheme, AnimateShow = true, UsernameWatermark = "Username", EnablePasswordPreview = true });
      if (result == null)
      {
        MessageBox.Show("Loggin Failed");
      }
      else
      {
        AppContext.LoginHandlerInstance.TryLogin(result.Username, result.Password);
      }
    }

    public void PerfomAfterLogin()
    {
      // LoginHelper.Instance.PerformAfterLogin();
      UpdateTitleBar();
      CheckForActivities();
      window.PerformAfterLogin();
    }

    public async void CheckForActivities()
    {
      var qry = (from us in HelpContext.Instance.ArticleNominations
                 where us.NominatedUser.ID_User == AppContext.LoggedInUser.ID_User
                 where us.IsSeen == false
                 select us).Take(5);
      if (qry.FirstOrDefault() != null)
      {
        string Articles = "";
        Articles += Environment.NewLine;
        foreach (ArticleNomination item in qry.ToList())
        {
          Articles += item.ArticleTitle;
          Articles += Environment.NewLine;
        }
        await this.ShowMessageAsync("You have been Nominated to create the following Articles" + Articles, "Information");
        var qry1 = from us in HelpContext.Instance.ArticleNominations
                   where us.NominatedUser.ID_User == AppContext.LoggedInUser.ID_User
                   where us.IsSeen == false
                   select us;
        foreach (var item in qry1)
        {
          item.IsSeen = true;
          item.SeenDate = DateTime.Now;
        }
        HelpContext.Instance.SaveChanges();
      }
    }

    public void UpdateTitleBar()
    {
      btnLogin.Visibility = Visibility.Collapsed;
      btnRegister.Visibility = Visibility.Collapsed;
      btnAccount.Visibility = Visibility.Visible;
      btnCreateNewEntry.Visibility = Visibility.Visible;
      btnAccount.Content = AppContext.LoggedInUser.Vorname + " " + AppContext.LoggedInUser.Nachname;
      ContentP.Content = new StartUpWindow();
    }

    private void btnCreateNewEntry_Click(object sender, RoutedEventArgs e)
    {
      AppContext.WindowManagerInstance.OpenNewWindow(new CreateArticle());
    }

    private void btnSettings_Click(object sender, RoutedEventArgs e)
    {
      flyout.IsOpen = true;
    }

    private void btnInfo_Click(object sender, RoutedEventArgs e)
    {
      flyout.IsOpen = true;
    }

    private void btnAccount_Click(object sender, RoutedEventArgs e)
    {
      AppContext.WindowManagerInstance.OpenNewWindow(new UserProfileOwn(AppContext.LoggedInUser));
    }

    private void flyout_IsOpenChanged(object sender, RoutedEventArgs e)
    {
      contentflyout.Content = new UserFlyout();
    }

    private void btnProposeArticle_Click(object sender, RoutedEventArgs e)
    {
      AppContext.WindowManagerInstance.OpenNewWindow(new ProposeArticle());
    }

    private void btnChat_Click(object sender, RoutedEventArgs e)
    {
      ChatWindow window = new ChatWindow();
      window.Show();
    }

    private void btnTran_Click(object sender, RoutedEventArgs e)
    {
      AppContext.WindowManagerInstance.OpenNewWindow(new SelfTranslate());
    }
  }
}