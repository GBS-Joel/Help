using Help.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Timers;
using System.Windows;
using System.Windows.Controls;

namespace Help.Stats
{
  public partial class GaugeBugReports : UserControl, INotifyPropertyChanged
  {
    private Timer t;

    public event PropertyChangedEventHandler PropertyChanged;

    public GaugeBugReports()
    {
      t = new Timer(60000);
      t.Elapsed += T_Elapsed1;
      t.AutoReset = true;
      t.Enabled = true;
      InitializeComponent();
      LoadData();
      DataContext = this;
      OnNotifyPropertyChaned();
    }

    private void T_Elapsed1(object sender, ElapsedEventArgs e)
    {
      LoadData();
    }

    public void OnNotifyPropertyChaned()
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
    }

    public int Value { get; set; }

    public void LoadData()
    {
      HelpContext.Instance.Dispose();
      HelpContext.InitInstance();
      var qry = from b in HelpContext.Instance.BugReports
                select b;
      List<BugReport> Report = qry.Where(x => x.ReportTime.Month == DateTime.Now.Month && x.ReportTime.Year == DateTime.Now.Year).ToList();
      Value = Report.Count;
      OnNotifyPropertyChaned();
      MessageBox.Show("TESt");
      t.AutoReset = true;
      t.Enabled = true;
    }
  }
}