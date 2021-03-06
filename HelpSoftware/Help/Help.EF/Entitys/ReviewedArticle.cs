﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class ReviewedArticle : IHelpEntity
  {
    [Key]
    public virtual int ID_ReviewedArticle { get; set; }

    public virtual User ReviewedUser { get; set; }

    public virtual Article ArticleReviewed { get; set; }

    public virtual DateTime? ReviewTime { get; set; }

    public virtual string Comment { get; set; }

    [Timestamp]
    public virtual byte[ ] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "ReviewedArticle";
    }

    public int GetID()
    {
      return ID_ReviewedArticle;
    }

    public bool GetWriteHistoryEntry()
    {
      return true;
    }
  }
}