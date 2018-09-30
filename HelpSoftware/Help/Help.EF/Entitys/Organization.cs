using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class Organization : IHelpEntity
  {
    [Key]
    public int ID_Organization { get; set; }

    public string Name { get; set; }

    public string Website { get; set; }

    public string Email { get; set; }

    public ICollection<Team> Teams { get; set; }

    public User Author { get; set; }

    public ICollection<User> Admins { get; set; }

    public ICollection<User> OUsers { get; set; }

    public DateTime Created { get; set; }

    public string Location { get; set; }

    [Timestamp]
    public byte[] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "Organization";
    }

    public int GetID()
    {
      return ID_Organization;
    }

    public bool GetWriteHistoryEntry()
    {
      return true;
    }
  }
}