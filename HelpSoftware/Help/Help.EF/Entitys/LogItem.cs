using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class LogItem : IHelpEntity
  {
    [Key]
    public virtual int ID_LogItem { get; set; }

    public virtual string Text { get; set; }

    public virtual DateTime Time { get; set; }

    public virtual User User { get; set; }

    //TODO Change to WerteBereich Item
    public virtual int Magnitude { get; set; }

    public virtual bool Verbose { get; set; }

    //For Verbose
    public virtual string ExtraInfo { get; set; }

    [Timestamp]
    public byte[] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "LogItem";
    }

    public int GetID()
    {
      return ID_LogItem;
    }

    public bool GetWriteHistoryEntry()
    {
      return false;
    }
  }
}