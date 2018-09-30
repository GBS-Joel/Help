using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class Article : IHelpEntity
  {
    [Key]
    public virtual int ID_Article { get; set; }

    public virtual string ArticleText { get; set; }

    public virtual string ArticlePreview { get; set; }

    public virtual string ArticleTitle { get; set; }

    public virtual List<Tag> Tags { get; set; }

    public virtual List<Topic> Topics { get; set; }

    public virtual User Author { get; set; }

    public virtual DateTime? Created { get; set; }

    public virtual User LastModifiedBy { get; set; }

    public virtual DateTime? LastModifiedDate { get; set; }

    public virtual int? Views { get; set; }

    public virtual int Stars { get; set; }

    public virtual int Favorits { get; set; }

    public virtual bool Public { get; set; }

    public virtual bool IsReviewed { get; set; }

    [Timestamp]
    public virtual byte[] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "Article";
    }

    public int GetID()
    {
      return ID_Article;
    }

    public bool GetWriteHistoryEntry()
    {
      return true;
    }
  }
}