using MahApps.Metro.Controls;
using System;
using System.Linq;
using System.Windows;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro;

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



      StartUpWindow w = new StartUpWindow();
      window = w;
      ContentP.Content = w;
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
          Setting usetting = SettingsHandler.Instance.GetSettingFromName("AppTheme");

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
      Tuple<AppTheme, Accent> theme = ThemeManager.DetectAppStyle(Application.Current);
      Random r = new Random();
      int random = r.Next(0, Enum.GetNames(typeof(ApplicationThemes)).Length - 1);
      var vals = Enum.GetValues(typeof(ApplicationThemes));
      ApplicationThemes a = (ApplicationThemes)vals.GetValue(random);
      ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent(a.ToString()), theme.Item1);
    }

    public void ChangeAppStyle(string Theme)
    {
      ThemeManager.ChangeAppTheme(Application.Current, Theme);
    }

    private void btnRegister_Click(object sender, RoutedEventArgs e)
    {
      Registration reg = new Registration();
      reg.Show();
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
        //var qry = from user in HelpContext.Instance.Users
        //          where user.Username == result.Username
        //          select user;
        //User u = qry.FirstOrDefault();
        //if (HashGenerator.Verify(result.Password, u.Password))
        //{
        //  AppContext.LoggedInUser = u;
        //  AppContext.IsLoggedIn = true;
        //  LoginHistory h = new LoginHistory()
        //  {
        //    LoggedInTime = DateTime.Now,
        //    LoggedInUser = u
        //  };
        //  HelpContext.Instance.LoginHistorys.Add(h);
        //  HelpContext.Instance.SaveChanges();
        //  PerfomAfterLogin();
        //}
        //else
        //{
        //  MessageBox.Show("Loggin Failed");
        //}
        if (LoginHelper.Instance.TryLogin(result.Username, result.Password, LoginType.SelfLogin))
        {
          PerfomAfterLogin();
        }
      }
    }

    public void PerfomAfterLogin()
    {
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

    public void TryLoadAppTheme()
    {
      var qry = (from us in HelpContext.Instance.UserSettings
                 where us.User.ID_User == AppContext.LoggedInUser.ID_User
                 where us.Setting.SettingName == "AppTheme"
                 select us).Take(5);
      //The user has a value 
      if (qry.FirstOrDefault() != null)
      {
        UserSetting s = qry.FirstOrDefault();
        string theme = s.UserValue;
        ChangeAppStyle(theme);
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
      CreateArticle art = new CreateArticle();
      art.Show();
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
      UserProfileOwn own = new UserProfileOwn(AppContext.LoggedInUser);
      own.Show();
    }

    private void flyout_IsOpenChanged(object sender, RoutedEventArgs e)
    {
      contentflyout.Content = new UserFlyout();
    }

    private void btnProposeArticle_Click(object sender, RoutedEventArgs e)
    {
      ProposeArticle prop = new ProposeArticle();
      prop.Show();
    }
  }
}