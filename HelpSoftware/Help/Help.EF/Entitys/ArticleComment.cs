using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class ArticleComment : IHelpEntity
  {
    [Key]
    public virtual int ID_ArticleComment { get; set; }

    public virtual string Comment { get; set; }

    public virtual string CommentTitle { get; set; }

    public virtual User UserComment { get; set; }

    public virtual Article CommentArticle { get; set; }

    public virtual DateTime CommentTime { get; set; }

    [Timestamp]
    public virtual byte[] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "ArticleComment";
    }

    public int GetID()
    {
      return ID_ArticleComment;
    }

    public bool GetWriteHistoryEntry()
    {
      return true;
    }
  }
}