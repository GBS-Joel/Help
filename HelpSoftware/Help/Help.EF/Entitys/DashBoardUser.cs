using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class DashBoardUser : IHelpEntity
  {
    [Key]
    public virtual int ID_DashBoardUser { get; set; }

    public virtual DashBoard DashBoard { get; set; }

    public virtual User User { get; set; }

    public virtual DateTime Created { get; set; }

    [Timestamp]
    public virtual byte[ ] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "DashBoardUser";
    }

    public int GetID()
    {
      return ID_DashBoardUser;
    }

    public bool GetWriteHistoryEntry()
    {
      return true;
    }
  }
}