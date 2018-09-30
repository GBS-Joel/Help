using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class WerteBereichValueRangeItem : IHelpEntity
  {
    [Key]
    public virtual int ID_WerteBereichValue { get; set; }

    public virtual WerteBereichValueRangeItemType Type { get; set; }

    public virtual string ValueName { get; set; }

    public virtual string Value { get; set; }

    public virtual DateTime Created { get; set; }

    [Timestamp]
    public byte[ ] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "WerteBereichValueRangeItem";
    }

    public int GetID()
    {
      return ID_WerteBereichValue;
    }

    public bool GetWriteHistoryEntry()
    {
      return false;
    }
  }
}