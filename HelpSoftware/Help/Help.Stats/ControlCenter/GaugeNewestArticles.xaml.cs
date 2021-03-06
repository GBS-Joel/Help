﻿using Help.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Timers;
using System.Windows;
using System.Windows.Controls;

namespace Help.Stats
{
  public partial class GaugeNewestArticles : UserControl, INotifyPropertyChanged
  {
    private Timer t;

    public GaugeNewestArticles()
    {
      t = new Timer(300000);
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

    public event PropertyChangedEventHandler PropertyChanged;

    public void OnNotifyPropertyChaned()
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
    }

    public int Value { get; set; }

    public void LoadData()
    {
      HelpContext.Instance.Dispose();
      HelpContext.InitInstance();
      var qry = from b in HelpContext.Instance.Articles
                select b;
      List<Article> Report = qry.Where(x => x.Created.Value.Month == DateTime.Now.Month && x.Created.Value.Year == DateTime.Now.Year).ToList();
      Value = Report.Count;
      OnNotifyPropertyChaned();
      MessageBox.Show("TESt");
    }
  }
}