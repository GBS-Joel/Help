using Help.EF;
using Help.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Help
{
  public partial class DashBoardConfiguration : HelpUserControl
  {
    public List<DashBoardConfigListBoxItem> Items { get; set; }

    public DashBoardConfiguration()
    {
      InitializeComponent();
      var qry = from u in HelpContext.Instance.DashBoards
                select u;
      List<DashBoard> Boards = qry.ToList();
      List<DashBoardConfigListBoxItem> Conf = new List<DashBoardConfigListBoxItem>();
      foreach (var item in Boards)
      {
        Conf.Add(new DashBoardConfigListBoxItem(item) { Width = pnale.Width });
      }
      Items = Conf;
      foreach (var item in Conf)
      {
        pnale.Children.Add(item);
      }
    }

    private void Save_Click(object sender, RoutedEventArgs e)
    {
      foreach (var item in Items)
      {
        if (item.IsTicked)
        {
          DashBoardUser u = new DashBoardUser()
          {
            Created = DateTime.Now,
            User = AppContext.LoggedInUser,
            DashBoard = item.CurrentDashBoard
          };
          HelpContext.Instance.DashBoardUsers.Add(u);
        }
      }
      HelpContext.Instance.SaveChanges();
    }
  }
}