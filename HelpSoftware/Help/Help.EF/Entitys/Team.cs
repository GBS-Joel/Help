using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class Team : IHelpEntity
  {
    [Key]
    public int ID_Team { get; set; }

    public string Name { get; set; }

    public string DisplayName { get; set; }

    public User Author { get; set; }

    //The Same as Admin
    public ICollection<User> SuperUsers { get; set; }

    //can add people but not remove
    //word out a concept for this
    public ICollection<User> Mods { get; set; }

    //The Users of the Team
    public ICollection<User> Members { get; set; }

    public Organization Organization { get; set; }

    [Timestamp]
    public byte[] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "Team";
    }

    public int GetID()
    {
      return ID_Team;
    }

    public bool GetWriteHistoryEntry()
    {
      return true;
    }
  }
}