using Help.EF;
using Help.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Help
{
  public partial class UserProfileOwn : HelpUserControl
  {
    public User CurrentUser { get; set; }

    private UserProfileOwn()
    {
      List<UserSetting> Settings = new List<UserSetting>();
      InitializeComponent();
    }

    public UserProfileOwn(User user)
    {
      InitializeComponent();
      CurrentUser = user;
      Model = new UserProfileOwnModel(user);
    }

    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
      HelpContext.Instance.Entry(CurrentUser).State = System.Data.Entity.EntityState.Modified;
      HelpContext.Instance.SaveChanges();
    }

    private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
    {
      cbAppTheme.ItemsSource = Enum.GetValues(typeof(ApplicationThemes));
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

    private void ToggleSwitch_Checked(object sender, RoutedEventArgs e)
    {
      cbAppTheme.IsEnabled = false;
    }

    private void ToggleSwitch_Unchecked(object sender, RoutedEventArgs e)
    {
      cbAppTheme.IsEnabled = true;
    }

    public override void DisplayData()
    {
      base.DisplayData();
      lboxActivity.Items.Clear();
      foreach (Activity item in ((UserProfileOwnModel)(Model)).Activites)
      {
        ActivityListBoxItem boxitem = new ActivityListBoxItem(item);
        boxitem.MaxWidth = lboxActivity.Width;
        lboxActivity.Items.Add(boxitem);
      }
    }



    public override void HandleInitLoad()
    {
      base.HandleInitLoad();
      btnSaveUserProfile.CustomSaveMethod = ((UserProfileOwnModel)Model).SaveUserProfile;
      //btnSaveUserProfile.CustomSaveMethod = ((UserProfileOwnModel)Model).SaveUserSettings;
    }
  }
}