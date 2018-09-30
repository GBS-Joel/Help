using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class User : IHelpEntity
  {
    [Key]
    public virtual int ID_User { get; set; }

    public virtual string Username { get; set; }

    public virtual string Password { get; set; }

    public virtual string EMail { get; set; }

    public virtual string Vorname { get; set; }

    public virtual string Nachname { get; set; }

    public virtual string Nick { get; set; }

    public virtual DateTime Birth { get; set; }

    public virtual bool IsVerified { get; set; }

    public virtual bool IsActive { get; set; }

    public virtual string ImagePath { get; set; }

    public virtual bool IsAdminUser { get; set; }

    public virtual ICollection<Organization> Admin { get; set; }

    public virtual ICollection<Organization> OUsers { get; set; }

    public virtual ICollection<Team> Teams { get; set; }

    [Timestamp]
    public virtual byte[ ] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "User";
    }

    public int GetID()
    {
      return ID_User;
    }

    public bool GetWriteHistoryEntry()
    {
      return true;
    }

    public override string ToString() => Vorname + " " + Nachname;
  }
}