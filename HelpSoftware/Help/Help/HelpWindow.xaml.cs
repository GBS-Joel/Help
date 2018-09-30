using Help.EF;
using Help.Library;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Help
{
  public partial class HelpWindow : MetroWindow, IRefreshAfterLogin
  {
    public bool IsClosing { get; set; }

    public HelpWindow()
    {
      DataContext = this;
      InitializeComponent();
      AppContext.WindowManagerInstance.SetContentPresenter(Content);
      AppContext.MainWindow = this;
    }

    protected override void OnClosing(CancelEventArgs e)
    {
      IsClosing = true;
      if (!AppContext.WindowManagerInstance.CheckIfClientCanClose())
      {
        //Confirm close
        if (MessageBox.Show("You may not Close at this State, Still Close?", "Error", MessageBoxButton.YesNo) == MessageBoxResult.No)
        {
          e.Cancel = true;
          IsClosing = false;
        }
      }
      base.OnClosing(e);
    }

    public void PerfomAfterLogin()
    {
      // LoginHelper.Instance.PerformAfterLogin();
      UpdateTitleBar();
      CheckForActivities();
    }

    public async void CheckForActivities()
    {
      var qry = (from us in HelpContext.Instance.ArticleNominations
                 where us.NominatedUser.ID_User == AppContext.LoggedInUser.ID_User
                 where us.IsSeen == false
                 select us).Take(5);
      if (qry.FirstOrDefault() != null)
      {
        string Articles = "";
        Articles += Environment.NewLine;
        foreach (ArticleNomination item in qry.ToList())
        {
          Articles += item.ArticleTitle;
          Articles += Environment.NewLine;
        }
        await this.ShowMessageAsync("You have been Nominated to create the following Articles" + Articles, "Information");
        var qry1 = from us in HelpContext.Instance.ArticleNominations
                   where us.NominatedUser.ID_User == AppContext.LoggedInUser.ID_User
                   where us.IsSeen == false
                   select us;
        foreach (var item in qry1)
        {
          item.IsSeen = true;
          item.SeenDate = DateTime.Now;
        }
        HelpContext.Instance.SaveChanges();
      }
    }

    public void UpdateTitleBar()
    {
      btnLogin.Visibility = Visibility.Collapsed;
      btnRegister.Visibility = Visibility.Collapsed;
      btnAccount.Visibility = Visibility.Visible;
      btnCreateNewEntry.Visibility = Visibility.Visible;
      btnAccount.Content = AppContext.LoggedInUser.Vorname + " " + AppContext.LoggedInUser.Nachname;
    }

    protected override void OnPreviewKeyDown(KeyEventArgs e)
    {
      base.OnPreviewKeyDown(e);
      if (e.Key == Key.F5)
      {
        AppContext.WindowManagerInstance.SetCurrentWindowToSaved();
      }
      else if (e.Key == Key.D)
      {
        if (Keyboard.IsKeyDown(Key.LeftCtrl))
        {
          Debugger.Debugger.Launch();
        }
      }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);
      AppContext.OpenConnectionHandler.UpdateOpenConnection();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      AppContext.WindowManagerInstance.OpenNewWindow(new StartUpWindow() { CanClose = true });
    }

    private void btnCreateNewEntry_Click(object sender, RoutedEventArgs e)
    {
      AppContext.WindowManagerInstance.OpenNewWindow(new CreateArticle());
    }

    private void btnSettings_Click(object sender, RoutedEventArgs e)
    {
      flyout.IsOpen = true;
    }

    private void btnInfo_Click(object sender, RoutedEventArgs e)
    {
      flyout.IsOpen = true;
    }

    private void btnAccount_Click(object sender, RoutedEventArgs e)
    {
      AppContext.WindowManagerInstance.OpenNewWindow(new UserProfileOwn(AppContext.LoggedInUser));
    }

    private void flyout_IsOpenChanged(object sender, RoutedEventArgs e)
    {
      contentflyout.Content = new UserFlyout();
    }

    private void btnProposeArticle_Click(object sender, RoutedEventArgs e)
    {
      AppContext.WindowManagerInstance.OpenNewWindow(new ProposeArticle());
    }

    private void btnChat_Click(object sender, RoutedEventArgs e)
    {
      ChatWindow window = new ChatWindow();
      window.Show();
    }

    private void btnTran_Click(object sender, RoutedEventArgs e)
    {
      AppContext.WindowManagerInstance.OpenNewWindow(new SelfTranslate());
    }

    private void btnRegister_Click(object sender, RoutedEventArgs e)
    {
      AppContext.WindowManagerInstance.OpenNewWindow(new Registrate());
    }

    private async void btnLogin_Click(object sender, RoutedEventArgs e)
    {
      LoginDialogData result = await this.ShowLoginAsync("Login", "Enter your credentials", new LoginDialogSettings { ColorScheme = this.MetroDialogOptions.ColorScheme, AnimateShow = true, UsernameWatermark = "Username", EnablePasswordPreview = true });
      if (result == null)
      {
        MessageBox.Show("Loggin Failed");
      }
      else
      {
        AppContext.LoginHandlerInstance.TryLogin(result.Username, result.Password);
        if (AppContext.IsLoggedIn)
        {
          AppContext.WindowManagerInstance.OpenNewWindow(new Main());
        }
      }
    }

    public void UpdateOnLogin()
    {
      PerfomAfterLogin();
    }

    public void UpdateOnLogOut()
    {
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      AppContext.WindowManagerInstance.OpenLastOpenedWindow();
    }

    private void PackIconFontAwesome_MouseUp(object sender, MouseButtonEventArgs e)
    {
      MessageBox.Show("Search " + tbSearchText.Text);
    }

    private void tbSearchText_KeyDown(object sender, KeyEventArgs e)
    {
      if (Key.Enter == e.Key)
      {
        MessageBox.Show("Search " + tbSearchText.Text);
      }
    }

    private void PackIconFontAwesome_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
    {
      MessageBox.Show("Search " + tbSearchText.Text);
    }

    private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {

    }

    private void Label_MouseUp(object sender, MouseButtonEventArgs e)
    {
      AppContext.WindowManagerInstance.OpenNewWindow(new CreateArticle());
    }

    private void PackIconModern_MouseUp(object sender, MouseButtonEventArgs e)
    {
      AppContext.WindowManagerInstance.OpenNewWindow(new Main());
    }
  }
}