using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class UserFavedArticles : IHelpEntity
  {
    [Key]
    public virtual int ID_UserFavedArticles { get; set; }

    public virtual User FavedUser { get; set; }

    public virtual Article FavedArticle { get; set; }

    public virtual DateTime FavedTime { get; set; }

    [Timestamp]
    public byte[ ] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "UserFavedArticles";
    }

    public int GetID()
    {
      return ID_UserFavedArticles;
    }

    public bool GetWriteHistoryEntry()
    {
      return false;
    }
  }
}