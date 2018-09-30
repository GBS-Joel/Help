using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class Chat : IHelpEntity
  {
    [Key]
    public virtual int ID_Chat { get; set; }

    public virtual User User1 { get; set; }

    public virtual User User2 { get; set; }

    public virtual DateTime Created { get; set; }

    public virtual User Initator { get; set; }

    [Timestamp]
    public virtual byte[] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "Chat";
    }

    public int GetID()
    {
      return ID_Chat;
    }

    public bool GetWriteHistoryEntry()
    {
      return false;
    }
  }
}