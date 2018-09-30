using MahApps.Metro;
using MahApps.Metro.SimpleChildWindow;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Help.Light
{
  public partial class Settings : ChildWindow
  {
    public bool IsSaved { get; set; }

    public MainWindow MainWindow { get; set; }

    public Settings(MainWindow window, LightSetting setting)
    {
      InitializeComponent();
      AppThemes.ItemsSource = Enum.GetValues(typeof(ApplicationThemes)).Cast<ApplicationThemes>();
      IsSaved = true;
      MainWindow = window;
      switchDark.IsChecked = setting.IsDarkThemeEnabled;
      switchRandom.IsChecked = setting.RandomAppThemeEnabled;
      AppThemes.Text = setting.Theme.ToString();
      switchRandom.IsChecked = setting.RandomAppThemeEnabled;
      AppThemes.IsEnabled = !setting.RandomAppThemeEnabled;
    }

    private void ToggleSwitch_Checked(object sender, RoutedEventArgs e)
    {
      AppThemes.IsEnabled = false;
      IsSaved = false;
    }

    private void ToggleSwitch_Unchecked(object sender, RoutedEventArgs e)
    {
      AppThemes.IsEnabled = true;
      IsSaved = false;
    }

    private void ChildWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      if (!IsSaved)
      {
        if (MessageBox.Show("Do You wish to Cancel?", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
        {
          e.Cancel = true;
        }
        else
        {
          CreateConfFile();
        }
      }
      else
      {
        CreateConfFile();
      }
    }

    private void CreateConfFile()
    {
      LightSetting setting = new LightSetting();
      string IsDarkThemeEnable = "";
      StringBuilder builder = new StringBuilder();
      builder.Append("<Setting>");
      if (switchDark.IsChecked == true)
      {
        IsDarkThemeEnable = "1";
        setting.IsDarkThemeEnabled = true;
        builder.Append("<DarkTheme>1</DarkTheme>");
      }
      else
      {
        IsDarkThemeEnable = "0";
        builder.Append("<DarkTheme>0</DarkTheme>");
      }
      string IsRandomAppThemeEnabled = "";

      if (switchRandom.IsChecked == true)
      {
        IsRandomAppThemeEnabled = "1";
        setting.RandomAppThemeEnabled = true;
        builder.Append("<RandomAppTheme>1</RandomAppTheme>");
      }
      else
      {
        IsRandomAppThemeEnabled = "0";
        setting.RandomAppThemeEnabled = false;
        builder.Append("<RandomAppTheme>0</RandomAppTheme>");
      }
      string RandomAppTheme = AppThemes.Text;
      if (AppThemes.Text != "")
      {
        setting.Theme = (ApplicationThemes)Enum.Parse(typeof(ApplicationThemes), AppThemes.Text);
        builder.Append("<AppTheme>" + setting.Theme + "</AppTheme>");
      }
      else
      {
        builder.Append("<AppTheme>" + setting.Theme + "</AppTheme>");
      }
      builder.Append("</Setting>");
      // MainWindow.ApplySetting(setting);
      SaveConfFile(builder.ToString());
    }

    public void SaveConfFile(string Content)
    {
      string filepath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
      string conpath = System.IO.Path.Combine(filepath, @"Help\Light_Setting.txt");
      if (File.Exists(conpath))
      {
        File.Delete(conpath);
      }
      using (StreamWriter sw = new StreamWriter(File.Create(conpath)))
      {
        sw.WriteLine(Content);
      }
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      IsSaved = true;
      Close();
    }
  }
}