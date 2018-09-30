using Help.EF;
using Help.Library;
using System;
using System.Windows;

namespace Help
{
  public partial class CreateBooklet : HelpUserControl
  {
    public CreateBooklet()
    {
      InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      if (AppContext.IsLoggedIn)
      {
        Booklet book = new Booklet()
        {
          Name = tbName.Text,
          Description = tbDesc.Text,
          Created = DateTime.Now,
          User = AppContext.LoggedInUser,
          Public = true,
          LastModified = DateTime.Now
        };
        HelpContext.Instance.Booklets.Add(book);
        HelpContext.Instance.SaveChanges();
      }
    }
  }
}