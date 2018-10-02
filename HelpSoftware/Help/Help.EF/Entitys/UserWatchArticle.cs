using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class UserWatchArticle : IHelpEntity
  {
    [Key]
    public virtual int ID_UserWatchArticle { get; set; }

    public virtual User WatchedUser { get; set; }

    public virtual Article WatchedArticle { get; set; }

    public virtual DateTime WatchedTime { get; set; }

    [Timestamp]
    public byte[ ] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "UserWatchArticle";
    }

    public int GetID()
    {
      return ID_UserWatchArticle;
    }

    public bool GetWriteHistoryEntry()
    {
      return false;
    }
  }
}