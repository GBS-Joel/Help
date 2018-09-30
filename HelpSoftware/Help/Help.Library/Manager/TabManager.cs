using Dragablz;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Help.Library
{
  public class TabManager
  {
    private TabablzControl TabControl { get; set; }  

    public void SetTabControl(TabablzControl TabControl)
    {
      AppContext.Logger.Debug("Set TabControl in TabManager");
      this.TabControl = TabControl;
    }

    private void TrySetBackground()
    {
      var rd = Application.Current.Resources.MergedDictionaries;
      object theValue = null;
      foreach (var item in rd)
      {
        if (theValue == null)
          theValue = item[ "AccentColorBrush" ];
      }
      string theString = theValue.ToString();
      Color color = (Color)ColorConverter.ConvertFromString(theString);
      SolidColorBrush brush = new SolidColorBrush(color);
      TabControl.Background = brush;
    }

    public void DisplayNewTab(IModuleElement Module)
    {
      AppContext.Logger.Debug("Display New Module in TabManager " + Module.Name);
      Module.Model?.LoadData();
      Module.HandleInitLoad();
      SetUpTabItem(Module);
      SetUpModelOnModule(Module);
      SetDefaultStretch(Module);
      Module.DisplayData();
    }

    private void SetDefaultStretch(IModuleElement Module)
    {
      if (Module.AutoStretch())
      {
        ((UserControl)Module).VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
        ((UserControl)Module).HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
      }
    }

    private void SetUpTabItem(IModuleElement Module)
    {
      TabItem item = new TabItem();
      ContextMenu menu = new ContextMenu();
      item.Content = Module;
      item.Header = Module.Title;
      item.Focus();
      TabControl.Items.Add(item);
      TabControl.SelectedItem = item;
      AppContext.WindowManagerInstance.CurrentOpenElement = Module;
    }

    private void SetUpModelOnModule(IModuleElement Module)
    {
      AppContext.Logger.Debug("LoadData on Model on GUI Element");
      Module.Model?.LoadData();
      SetDefaultBinding(Module as HelpUserControl);
    }

    public void SetDefaultBinding(HelpUserControl Module)
    {
      Module.DataContext = Module.Model;
    }

    internal void CloseActiveTab()
    {
      TabControl.Items.Remove(TabControl.Items[ TabControl.Items.Count - 1 ]);
      AppContext.WindowManagerInstance.CurrentOpenElement = null;
    }
  }
}