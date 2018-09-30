using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class ArticleNomination : IHelpEntity
  {
    [Key]
    public virtual int ID_ArticleNomination { get; set; }

    public virtual User NominatedUser { get; set; }

    public virtual User RequestedUser { get; set; }

    public virtual string ArticleTitle { get; set; }

    public virtual string ArticleDescription { get; set; }

    public virtual string Comment { get; set; }

    public virtual ICollection<Topic> Topics { get; set; }

    public virtual ICollection<Tag> Tags { get; set; }

    public virtual DateTime NominationedDate { get; set; }

    public virtual bool IsSeen { get; set; }

    public virtual DateTime SeenDate { get; set; }

    [Timestamp]
    public virtual byte[ ] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "ArticleNomination";
    }

    public int GetID()
    {
      return ID_ArticleNomination;
    }

    public bool GetWriteHistoryEntry()
    {
      return true;
    }
  }
}