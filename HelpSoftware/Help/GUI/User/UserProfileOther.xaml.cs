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
  public partial class UserProfileOther : MetroWindow
  {
    public string AuthorName { get; set; }

    public User CurrentUser { get; set; }

    public UserProfileOther(User user)
    {
      InitializeComponent();
      DataContext = this;
      CurrentUser = user;
      LoadUserProfile();
    }

    public void LoadUserProfile()
    {
      AuthorName = CurrentUser.Vorname + " " + CurrentUser.Nachname;
    }

    public void LoadUserActivity()
    {
      var qry = from act in HelpContext.Instance.Activities
                where act.ActivityUser.ID_User == CurrentUser.ID_User
                orderby act.ActivityOn descending
                select act;
      List<Activity> acts = new List<Activity>();
      acts = qry.ToList();
      List<ActivityListBoxItem> items = new List<ActivityListBoxItem>();
      foreach (Activity item in acts)
      {
        ActivityListBoxItem boxitem = new ActivityListBoxItem(item);
        boxitem.MaxWidth = lboxActivity.Width;
        items.Add(boxitem);
      }
      lboxActivity.ItemsSource = items;
    }

    private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
    {
      LoadUserActivity();
    }
  }
}