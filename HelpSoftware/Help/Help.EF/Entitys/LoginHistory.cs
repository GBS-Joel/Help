using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class LoginHistory : IHelpEntity
  {
    [Key]
    public virtual int ID_LoginHistory { get; set; }

    public virtual User LoggedInUser { get; set; }

    public virtual DateTime LoggedInTime { get; set; }

    //TODO: Change To Werbereberiech
    public virtual int LoginType { get; set; }

    [Timestamp]
    public virtual byte[ ] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "LoginHistory";
    }

    public int GetID()
    {
      return ID_LoginHistory;
    }

    public bool GetWriteHistoryEntry()
    {
      return false;
    }
  }
}