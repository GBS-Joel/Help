using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class PinWallComment : IHelpEntity
  {
    [Key]
    public virtual int ID_PinWallComment { get; set; }

    public virtual User Author { get; set; }

    public virtual User User { get; set; }

    public virtual DateTime CommentTime { get; set; }

    public virtual string CommentTitle { get; set; }

    public virtual string CommentText { get; set; }

    public virtual bool IsPublic { get; set; }

    public virtual bool IsDeleted { get; set; }

    public virtual bool IsAnonymous { get; set; }

    [Timestamp]
    public virtual byte[] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "PinWallComment";
    }

    public int GetID()
    {
      return ID_PinWallComment;
    }

    public bool GetWriteHistoryEntry()
    {
      return true;
    }
  }
}