using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class Project
  {
    [Key]
    public int ID_Project { get; set; }

    public string Name { get; set; }

    public string Beschreibung { get; set; }

    public string Color { get; set; }

    public bool RandomColor { get; set; }

    public string Password { get; set; }

    public bool Public { get; set; }

    public string InviteLink { get; set; }

    public bool CreatePassword { get; set; }

    public DateTime Created { get; set; }

    public User Creator { get; set; }
  }
}