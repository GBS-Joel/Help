using System;
using System.ComponentModel.DataAnnotations;

namespace Help
{
  public class User
  {
    [Key]
    public int ID_User { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public string EMail { get; set; }

    public string Vorname { get; set; }

    public string Nachname { get; set; }

    public string Nick { get; set; }

    public DateTime Birth { get; set; }

    public bool IsVerified { get; set; }

    public bool IsActive { get; set; }

    public string ImagePath { get; set; }

    public override string ToString()
    {
      return Vorname + " " + Nachname;
    }
  }
}