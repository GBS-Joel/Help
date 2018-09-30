using System;
using Help.EF;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Media;

namespace Help.Library
{
  public class HelpUserControl : UserControl, IRefreshAfterLogin, IModuleElement
  {
    public HelpUserControl()
    {
      VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
      HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
      Background = (Brush)FindResource("MaterialDesignPaper");
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnLoaded()
    {
      if (!IsInitialLoadPerformed)
      {
        HandleInitLoad();
        IsInitialLoadPerformed = true;
      }
    }

    private bool IsInitialLoadPerformed { get; set; }

    public WindowType WindowType { get; set; }

    public string Title { get; set; }

    public bool CanClose { get; set; }

    public bool RequirePermission { get; set; }

    public HelpPermission RequiredPermission { get; set; }

    public virtual IModel Model { get; set; }

    private bool _IsSaved { get; set; }

    public bool IsSaved
    {
      get
      {
        if (AppContext.IsAtRuntime)
        {
          return _IsSaved;
        }
        else
        {
          return true;
        }
      }
      set
      {
        _IsSaved = value;
      }
    }

    public virtual void DisplayData()
    {
      AppContext.Logger.Debug("Running Display Data on Module " + AppContext.WindowManagerInstance.CurrentOpenElement?.Name ?? "NO NAME");
      InvokePropertyChanedOnAllPropertys();
    }

    public virtual void HandleInitLoad()
    {
      AppContext.Logger.Debug("Running Handle Initial Load on Module " + AppContext.WindowManagerInstance.CurrentOpenElement?.Name ?? "NO NAME");
      this.IsInitialLoadPerformed = true;
    }

    public void InvokePropertyChanedOnAllPropertys()
    {
      if (Model != null && IsInitialLoadPerformed)
        // Get property array
        foreach (var item in GetProperties(Model))
        {
          string name = item.Name;
          //var value = item.GetValue(Model, null);
          this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    private static PropertyInfo[ ] GetProperties(object obj)
    {
      return obj.GetType().GetProperties();
    }

    public virtual void PerformAfterLogin()
    {
      ProvideRibbon();
    }

    public virtual void UdpateAfterDatabaseInitialized()
    {

    }

    public virtual void UpdateOnLogin()
    {
      ProvideRibbon();
    }

    public virtual void UpdateOnLogOut()
    {
      ProvideRibbon();
    }

    public bool IsCurrentPermissionEnough()
    {
      return AppContext.PermissionHandlerInstance.GetIsCurrentPermissionEnough();
    }

    public IModel GetModel()
    {
      return Model;
    }

    public void StartUp()
    {
      OnLoaded();
      DataContext = Model;
      CanClose = true;
    }

    public virtual List<RibbonTabPageDef> ProvideRibbon()
    {
      return null;
    }

    public List<LinkItem> ProvideLinks()
    {
      throw new NotImplementedException();
    }

    public bool CanNewBeExecuted()
    {
      return false;
    }

    public IModuleElement GetNewWindow()
    {
      return null;
    }

    public bool AutoStretch()
    {
      return true;
    }
  }
}