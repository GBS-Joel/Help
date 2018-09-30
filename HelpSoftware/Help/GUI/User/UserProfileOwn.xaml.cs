using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Help
{
  public partial class UserProfileOwn : MetroWindow
  {
    public User CurrentUser { get; set; }

    public UserProfileOwn()
    {
      InitializeComponent();
    }

    public UserProfileOwn(User user)
    {
      InitializeComponent();
      CurrentUser = user;
      LoadUserProfile();
      DataContext = this;
    }

    public void LoadUserProfile()
    {
      var qry = from us in HelpContext.Instance.UserSettings
                where us.Setting.SettingName == "AppTheme"
                where us.User.ID_User == CurrentUser.ID_User
                select us;
      if (qry.FirstOrDefault() != null)
      {
        UserSetting u = qry.FirstOrDefault();
        cbAppTheme.SelectedItem = u.UserValue;
      }
    }

    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
      HelpContext.Instance.Entry(CurrentUser).State = System.Data.Entity.EntityState.Modified;
      HelpContext.Instance.SaveChanges();
    }

    private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
    {
      cbAppTheme.ItemsSource = Enum.GetValues(typeof(ApplicationThemes));
      LoadUserProfile();
    }

    private void btnSaveSettings_Click(object sender, RoutedEventArgs e)
    {
      string AppTheme = cbAppTheme.SelectedItem.ToString();

      var qry = from us in HelpContext.Instance.UserSettings
                where us.User.ID_User == CurrentUser.ID_User
                where us.Setting.SettingName == "AppTheme"
                select us;
      if (qry.FirstOrDefault() == null)
      {
        var qry1 = from set in HelpContext.Instance.Settings
                   where set.SettingName == "AppTheme"
                   select set;
        Setting a = qry1.FirstOrDefault();
        UserSetting s = new UserSetting()
        {
          Created = DateTime.Now,
          Setting = a,
          User = CurrentUser,
          UserValue = AppTheme
        };

        HelpContext.Instance.UserSettings.Add(s);
        HelpContext.Instance.SaveChanges();
      }
      else
      {
        UserSetting a = qry.FirstOrDefault();
        a.UserValue = AppTheme;
        a.LastChanged = DateTime.Now;
        HelpContext.Instance.SaveChanges();
      }
    }
  }
}