using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class ArticleTag : IHelpEntity
  {
    [Key]
    public virtual int ID_ArticleTag { get; set; }

    public virtual Article Article { get; set; }

    public virtual Tag Tag { get; set; }

    public virtual DateTime AssingTime { get; set; }

    public virtual User User { get; set; }

    [Timestamp]
    public virtual byte[ ] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "ArticleTag";
    }

    public int GetID()
    {
      return ID_ArticleTag;
    }

    public bool GetWriteHistoryEntry()
    {
      return true;
    }
  }
}