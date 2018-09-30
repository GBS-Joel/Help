using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class WertebereichDef : IHelpEntity
  {
    public WertebereichDef()
    {
      WerteBereichValueRanges = new List<WerteBereichValueRange>();
    }

    [Key]
    public virtual int ID_WertebereichDef { get; set; }

    public virtual string Name { get; set; }

    public virtual DateTime Created { get; set; }

    public virtual bool AutomaticCreated { get; set; }

    public string DefaultValue { get; set; }

    public virtual ICollection<WerteBereichValueRange> WerteBereichValueRanges { get; set; }

    [Timestamp]
    public byte[ ] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "WertebereichDef";
    }

    public int GetID()
    {
      return ID_WertebereichDef;
    }

    public bool GetWriteHistoryEntry()
    {
      return false;
    }
  }
}