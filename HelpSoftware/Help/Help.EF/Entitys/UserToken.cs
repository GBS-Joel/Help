using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class UserToken : IHelpEntity
  {
    [Key]
    public virtual int ID_UserToken { get; set; }

    public virtual User User { get; set; }

    public virtual DateTime Created { get; set; }

    public virtual string Token { get; set; }

    [Timestamp]
    public byte[] TimeStamp { get; set; }

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
      return false;
    }
  }
}