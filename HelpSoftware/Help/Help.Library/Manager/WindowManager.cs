using Dragablz;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Help.Library
{
  public class WindowManager
  {
    private IModuleElement StartUpWindow { get; set; }

    private bool IsInitalized { get; set; }

    private static List<IModuleElement> LastOpenedElements;

    public IModuleElement CurrentOpenElement { get; set; }

    private IModuleElement StartWindowForCurrentUser { get; set; }

    private ContentPresenter Presenter { get; set; }

    private Window MainWindow { get; set; }

    public WindowManager()
    {
      AppContext.Logger.Debug("Init WindowManager Instance");
      LastOpenedElements = new List<IModuleElement>();
      CurrentOpenElement = null;
      IsInitalized = true;
      TryOpenStartWindow();
    }

    private void MainWindow_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
    {

    }

    public void SetMainWindow(Window Window)
    {
      MainWindow = Window;
      MainWindow.MouseMove += MainWindow_MouseMove;
      MainWindow.KeyDown += MainWindow_KeyDown;
    }

    private void MainWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
    {
      if (e.Key == System.Windows.Input.Key.F5)
      {
        AppContext.WindowManagerInstance.CurrentOpenElement.Model.ReloadData();
      }
    }

    public void SetContentPresenter(ContentPresenter presenter)
    {
      AppContext.Logger.Debug("Set Content Presenter");
      Presenter = presenter;
    }

    private void SetStartupWindow(IModuleElement Element)
    {
      AppContext.Logger.Debug("Set Startup Window");
      StartUpWindow = Element;
    }

    public void RefreshCurrentWindow()
    {
      if (CurrentOpenElement != null)
      {
        AppContext.Logger.Debug("Refresh Window " + CurrentOpenElement.Name);
        CurrentOpenElement.DisplayData();
        if (CurrentOpenElement.Model != null)
        {
          CurrentOpenElement.GetModel().ReloadData();
          WindowChanged();
        }
      }
    }

    public void OpenNewWindow(IModuleElement element)
    {
      AppContext.Logger.Debug("Open New Window " + element.Name);
      element.StartUp();
      element.Model?.LoadData();
      element.Model?.NotifyChanged();
      element.HandleInitLoad();
      Presenter.Content = element;
      ((UserControl)element).DataContext = element.Model;
      element.DisplayData();
      if (element.Model != null)
        element.Model.IsSaved = true;
      element.Model?.NotifyChanged();
      CurrentOpenElement = element;
      SetCurrentWindowToSaved();
    }

    public void OpenNewWindow(IModuleElement element, IModel model)
    {
      AppContext.Logger.Debug("Open New Window " + element.Name);
      element.Model = model;
      OpenNewWindow(element);
      WindowChanged();
    }

    public void CloseActiveWindow()
    {
      if (CurrentOpenElement != null)
      {
        AppContext.Logger.Debug("Close the Active Window " + CurrentOpenElement.Name);
        if (CurrentOpenElement.CanClose)
        {
          if (StartWindowForCurrentUser == null)
          {

          }
          else
          {
            CurrentOpenElement = StartWindowForCurrentUser;
            LastOpenedElements.Insert(0, CurrentOpenElement);
            CurrentOpenElement.HandleInitLoad();
            OpenNewWindow(CurrentOpenElement);
            CurrentOpenElement.DisplayData();
            WindowChanged();
          }
        }
        else
        {
          if (MessageBox.Show("You may not Close at this State, Still Close?", "Error", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
          {

          }
        }
      }
    }

    public void TryOpenStartWindow()
    {
      AppContext.Logger.Debug("Try Open Start Window");
      CloseActiveWindow();
      WindowChanged();
    }

    public void GetStartWindowForCurrentUser()
    {

    }

    public bool CheckIfClientCanClose()
    {
      if (CurrentOpenElement != null)
      {
        return CurrentOpenElement.CanClose;
      }
      else
      {
        return true;
      }
    }

    public void PerformAfterLogin()
    {
      AppContext.Logger.Debug("Perfrom After Login On Window Manager");
      ((IRefreshAfterLogin)MainWindow).UpdateOnLogin();
      CurrentOpenElement.PerformAfterLogin();
      CurrentOpenElement.DisplayData();
      WindowChanged();
    }

    public void OpenLastOpenedWindow()
    {
      OpenNewWindow(LastOpenedElements[ 1 ]);
      LastOpenedElements.RemoveAt(0);
      WindowChanged();
    }

    public void MarkCurrentElementAsNotSaved()
    {
      if (CurrentOpenElement.Model != null)
      {
        CurrentOpenElement.Model.IsSaved = false;
        CurrentOpenElement.Model.NotifyChanged("IsSaved");
      }
    }

    public void SaveCurrentWindow()
    {
      AppContext.SaveManagerInstance.Save();
      SetCurrentWindowToSaved();
    }

    public void SetCurrentWindowToSaved()
    {
      if (CurrentOpenElement != null && CurrentOpenElement.Model is IModel)
      {
        CurrentOpenElement.Model.IsSaved = true;
        CurrentOpenElement.Model.NotifyChanged();
      }
    }

    public void ReOpenCurrentWindow()
    {
      Type c = CurrentOpenElement.GetType();
      object res = Activator.CreateInstance(c);
      OpenNewWindow((IModuleElement)res);
    }

    public void WindowChanged()
    {

    }
  }
}