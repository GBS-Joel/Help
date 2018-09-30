using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class BookletArticle : IHelpEntity
  {
    [Key]
    public virtual int ID_BookletArticle { get; set; }

    public virtual Booklet Book { get; set; }

    public virtual Article Article { get; set; }

    public virtual DateTime AssingTime { get; set; }

    [Timestamp]
    public virtual byte[] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "BookletArticle";
    }

    public int GetID()
    {
      return ID_BookletArticle;
    }

    public bool GetWriteHistoryEntry()
    {
      return true;
    }
  }
}