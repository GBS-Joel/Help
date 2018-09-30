using System.Windows;
using Help.EF;
using Help.Library;

namespace Help
{
  public class RegistrateModel : BaseModel<RegistrateModel>
  {
    public string Vorname { get; set; }

    public string Nachname { get; set; }

    public string EMail { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public string Password2 { get; set; }

    public override IModuleElement Owner { get; set; }

    public RegistrateModel ModelInstance { get; set; }

    public override int GetID()
    {
      return 0;
    }

    public void Registrate()
    {
      RegisterHandler register = new RegisterHandler();
      if (Password == Password2)
      {
        User u = new User()
        {
          Vorname = Vorname,
          Nachname = Nachname,
          EMail = EMail,
          Username = Username,
          Password = Password,
        };
        register.Registrate(u);
      }
      else
      {
        MessageBox.Show("Error Passwords do not match");
      }
    }
  }
}