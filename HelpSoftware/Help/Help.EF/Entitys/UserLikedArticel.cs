using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class UserLikedArticel : IHelpEntity
  {
    [Key]
    public virtual int ID_UserLikedArticel { get; set; }

    public virtual User LikedUser { get; set; }

    public virtual Article LikedArticel { get; set; }

    public virtual DateTime LikedTime { get; set; }

    [Timestamp]
    public virtual byte[ ] TimeStamp { get; set; }

    public string GetEntityName()
    {
      throw new NotImplementedException();
    }

    public int GetID()
    {
      throw new NotImplementedException();
    }

    public bool GetWriteHistoryEntry()
    {
      return true;
    }
  }
}