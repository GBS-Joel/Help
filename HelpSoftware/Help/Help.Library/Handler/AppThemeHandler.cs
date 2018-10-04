using Fluent;
using Help.EF;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;

//Handle Theme and Dark and Light Theme
namespace Help.Library
{
  public static class AppThemeHandler
  {
    public static string AppColorTheme { get; set; }

    public static bool UseDarkTheme { get; set; } = true;

    public static void UpdateAppTheme()
    {
      TryLoadAppTheme();
      TryLoadBaseTheme();
      UpdateAppThemes();
    }

    private static void TryLoadAppTheme()
    {
      var qry = (from us in HelpContext.Instance.UserSettings
                 where us.User.ID_User == AppContext.LoggedInUser.ID_User
                 where us.Setting.SettingName == "AppTheme"
                 select us).Take(5);
      //The user has a value
      if (qry.FirstOrDefault() != null)
      {
        UserSetting s = qry.FirstOrDefault();
        AppColorTheme = Enum.GetName(typeof(ApplicationThemes), Convert.ToInt32(s.UserValue));
      }
    }

    private static void TryLoadBaseTheme()
    {
      var value = HelpService.GetService<UserSettingService>().GetUserSettingFromName("UseDarkTheme", AppContext.LoggedInUser.ID_User)?.UserValue;
      if (value == "1")
      {
        UseDarkTheme = true;
      }
      else
      {
        UseDarkTheme = false;
      }
    }

    private static void UpdateAppThemes()
    {
      UpdateBaseAppTheme();
      ChangeAppStyle();
    }

    private static void UpdateBaseAppTheme()
    {
      if (UseDarkTheme)
      {
        Application.Current.Resources[ "DarkBackgroundOne" ] = (SolidColorBrush)(new BrushConverter().ConvertFrom("#303030"));
      }
      else
      {
        Application.Current.Resources[ "DarkBackgroundOne" ] = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
      }
    }

    public static void ChangeAppStyle()
    {
      if (UseDarkTheme)
      {
        ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent(AppColorTheme), ThemeManager.GetAppTheme("BaseDark"));
      }
      else
        ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent(AppColorTheme), ThemeManager.GetAppTheme("BaseLight"));
    }

    public static void GetRandomColor()
    {
      Tuple<AppTheme, Accent> theme = ThemeManager.DetectAppStyle(Application.Current);
      Random r = new Random();
      int random = r.Next(0, Enum.GetNames(typeof(ApplicationThemes)).Length - 1);
      var vals = Enum.GetValues(typeof(ApplicationThemes));
      ApplicationThemes a = (ApplicationThemes)vals.GetValue(random);
      ThemeManager.ChangeAppStyle(Application.Current, ThemeManager.GetAccent(a.ToString()), theme.Item1);
    }
  }
}