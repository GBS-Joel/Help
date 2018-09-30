using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class Verify : IHelpEntity
  {
    [Key]
    public virtual int ID_Verify { get; set; }

    public virtual User User { get; set; }

    public virtual DateTime Created { get; set; }

    public virtual string Token { get; set; }

    public virtual Boolean IsVerified { get; set; }

    public virtual DateTime? VerifyTime { get; set; }

    [Timestamp]
    public virtual byte[] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "Verify";
    }

    public int GetID()
    {
      return ID_Verify;
    }

    public bool GetWriteHistoryEntry()
    {
      return true;
    }
  }
}