using System;
using System.Windows;

namespace Help.Library
{
  public partial class ErrorMessageBox : Window
  {
    public string TitleError { get; set; }

    public string InnerMessage { get; set; }

    public Exception exception { get; set; }

    public void SetWindow()
    {
      DataContext = this;
      Title = exception.Message;
      InnerMessage = exception.StackTrace;
    }

    public ErrorMessageBox(Exception x)
    {
      InitializeComponent();
      exception = x;
      SetWindow();
    }

    public ErrorMessageBox(string title, string message, string StackTrace)
    {
      InitializeComponent();
      DataContext = this;
      TitleError = message;
      InnerMessage = StackTrace;
    }

    public ErrorMessageBox(HelpException x)
    {
      InitializeComponent();
      exception = x;
      SetWindow();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      Close();
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
      Clipboard.SetText(InnerMessage);
      MessageBox.Show("Inner Exception Saved To Clipboard", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
    }
  }
}