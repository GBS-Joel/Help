using Help.EF;
using Help.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Help
{
  public partial class UserProfileOther : HelpUserControl
  {
    public string AuthorName { get; set; }

    public User CurrentUser { get; set; }

    public override IModel Model { get; set; }

    public UserProfileOther(User user)
    {
      InitializeComponent();
      DataContext = this;
      CurrentUser = user;
      LoadUserProfile();
      LoadUserActivity();
      LoadPinWall();
    }

    public void LoadPinWall()
    {
      List<PinWallCommentOtherListBoxItem> lst = new List<PinWallCommentOtherListBoxItem>();
      var qry = from pw in HelpContext.Instance.PinWallComments
                where pw.User.ID_User == CurrentUser.ID_User
                where pw.IsPublic == true
                where pw.IsDeleted == false
                select pw;
      foreach (var item in qry.ToList())
      {
        PinWallCommentOtherListBoxItem c = new PinWallCommentOtherListBoxItem(item);
        c.Width = test.ActualWidth;
        lst.Add(c);
      }
      test.ItemsSource = lst;
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

    public override void DisplayData()
    {
      throw new NotImplementedException();
    }

    public override void HandleInitLoad()
    {
      throw new NotImplementedException();
    }

    public override void PerformAfterLogin()
    {
      throw new NotImplementedException();
    }

    public override void UdpateAfterDatabaseInitialized()
    {
      throw new NotImplementedException();
    }

    public override void UpdateOnLogin()
    {
      throw new NotImplementedException();
    }

    public override void UpdateOnLogOut()
    {
      throw new NotImplementedException();
    }
  }
}