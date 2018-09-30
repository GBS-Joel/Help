using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class UserSetting : IHelpEntity
  {
    [Key]
    public virtual int ID_UserSetting { get; set; }

    public virtual Setting Setting { get; set; }

    public virtual User User { get; set; }

    public virtual string UserValue { get; set; }

    public virtual DateTime Created { get; set; }

    public virtual DateTime LastChanged { get; set; }

    [Timestamp]
    public byte[ ] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "UserSetting";
    }

    public int GetID()
    {
      return ID_UserSetting;
    }

    public bool GetWriteHistoryEntry()
    {
      return true;
    }
  }
}