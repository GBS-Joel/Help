using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class ArticleViewHistory : IHelpEntity
  {
    [Key]
    public virtual int ID_ArticleViewHistory { get; set; }

    public virtual DateTime ViewTime { get; set; }

    public virtual User User { get; set; }

    public virtual Article Article { get; set; }

    [Timestamp]
    public virtual byte[ ] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "ArticleViewHistory";
    }

    public int GetID()
    {
      return ID_ArticleViewHistory;
    }

    public bool GetWriteHistoryEntry()
    {
      return false;
    }
  }
}