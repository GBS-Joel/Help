using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class ViewHistory : IHelpEntity
  {
    [Key]
    public virtual int ID_ViewHistory { get; set; }

    public virtual Article ViewedArticle { get; set; }

    public virtual User ViewedUser { get; set; }

    public virtual DateTime AccessTime { get; set; }

    [Timestamp]
    public byte[ ] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "ViewHistory";
    }

    public int GetID()
    {
      return ID_ViewHistory;
    }

    public bool GetWriteHistoryEntry()
    {
      return false;
    }
  }
}