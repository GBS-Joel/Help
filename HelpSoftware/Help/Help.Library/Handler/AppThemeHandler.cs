using Fluent;
using Help.EF;
using System;
using System.Linq;
using System.Windows;

namespace Help.Library
{
  public class AppThemeHandler
  {
    public static AppThemeHandler Instance { get; set; }

    public static void InitInstance()
    {
      Instance = new AppThemeHandler();
      Instance.GetRandomColor();
    }

    public void SetAppColor()
    {
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

    public void ChangeAppStyle(string Theme)
    {
      // ThemeManager.ChangeAppTheme(Application.Current, Theme);
    }

    public void GetRandomColor()
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