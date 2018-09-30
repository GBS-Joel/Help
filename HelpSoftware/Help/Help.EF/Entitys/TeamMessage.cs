using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class TeamMessage : IHelpEntity
  {
    [Key]
    public int ID_TeamMessage { get; set; }

    public string Title { get; set; }

    public string Message { get; set; }

    public Team Team { get; set; }

    public bool Deleted { get; set; }

    public DateTime Created { get; set; }

    public User Author { get; set; }

    [Timestamp]
    public byte[] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "TeamMessage";
    }

    public int GetID()
    {
      return ID_TeamMessage;
    }

    public bool GetWriteHistoryEntry()
    {
      return true;
    }
  }
}