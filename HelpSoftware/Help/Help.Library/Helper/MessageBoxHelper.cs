using System.Windows;

namespace Help.Library
{
  public class MessageBoxHelper
  {
    public void ShowMessageBox(string Message)
    {
      MessageBox.Show("Title", Message);
    }
  }
}