using MahApps.Metro.Controls;
using System;
using System.Linq;
using System.Windows;

namespace Help
{
  public partial class Registration : MetroWindow
  {
    public Registration()
    {
      InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      var qry = from u in HelpContext.Instance.Users
                where u.Username == tbUsername.Text
                select u;
      if (qry.FirstOrDefault() == null)
      {
        User u = new User()
        {
          Vorname = tbVorname.Text,
          Nachname = tbNachname.Text,
          Birth = DateTime.Now,
          EMail = tbEMail.Text,
          Password = HashGenerator.Hash(tbPW1.Text),
          Nick = "Nick",
          Username = tbUsername.Text,
          ImagePath = "test",
          IsActive = true,
          IsVerified = true
        };
        HelpContext.Instance.Users.Add(u);
        HelpContext.Instance.SaveChanges();
        HelpContext.Instance.Entry(u).Reload();
        MailHandler.Instance.SendActivationEMail(u);
        SettingsHandler.Instance.CreateSettingsForUser(u);
      }
    }
  }
}