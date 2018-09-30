using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class WerteBereich : IHelpEntity
  {
    [Key]
    public virtual int ID_WerteBereich { get; set; }

    public virtual string Name { get; set; }

    public virtual WertebereichDef WertebereichDef { get; set; }

    public virtual WerteBereichValueDataType DataType { get; set; }

    public virtual string Value { get; set; }

    public DateTime Created { get; set; }

    [Timestamp]
    public byte[ ] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "WerteBereich";
    }

    public int GetID()
    {
      return ID_WerteBereich;
    }

    public bool GetWriteHistoryEntry()
    {
      return false;
    }
  }
}