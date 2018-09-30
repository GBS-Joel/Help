using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class SystemSetting : IHelpEntity
  {
    [Key]
    public virtual int ID_SystemSetting { get; set; }

    public virtual string Name { get; set; }

    public virtual string Value { get; set; }

    public virtual DateTime Created { get; set; }

    //TODO Create WerteBereich
    public virtual WerteBereich WerteBereichValue { get; set; }

    [Timestamp]
    public byte[] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "SystemSetting";
    }

    public int GetID()
    {
      return ID_SystemSetting;
    }

    public bool GetWriteHistoryEntry()
    {
      return true;
    }
  }
}