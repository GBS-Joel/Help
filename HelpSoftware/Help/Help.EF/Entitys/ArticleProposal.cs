using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class ArticleProposal : IHelpEntity
  {
    [Key]
    public virtual int ID_ArticleProposal { get; set; }

    public virtual string ArticleTitle { get; set; }

    public virtual string ArticleDescription { get; set; }

    public virtual string Comment { get; set; }

    public virtual ICollection<Topic> Topics { get; set; }

    public virtual ICollection<Tag> Tags { get; set; }

    public virtual DateTime CreatedDate { get; set; }

    public virtual User AssignedUser { get; set; }

    public virtual string RequesterName { get; set; }

    public virtual string RequesterEMail { get; set; }

    [Timestamp]
    public virtual byte[ ] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "ArticleProposal";
    }

    public int GetID()
    {
      return ID_ArticleProposal;
    }

    public bool GetWriteHistoryEntry()
    {
      return true;
    }
  }
}