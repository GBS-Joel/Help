using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class ArticleNote : IHelpEntity
  {
    [Key]
    public virtual int ID_ArticleNote { get; set; }

    public virtual Article Article { get; set; }

    public virtual Note Note { get; set; }

    public virtual User User { get; set; }

    public virtual DateTime Created { get; set; }

    [Timestamp]
    public virtual byte[] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "ArticleNote";
    }

    public int GetID()
    {
      return ID_ArticleNote;
    }

    public bool GetWriteHistoryEntry()
    {
      return true;
    }
  }
}