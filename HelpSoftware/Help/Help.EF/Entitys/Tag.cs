using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class Tag : IHelpEntity
  {
    [Key]
    public virtual int ID_Tag { get; set; }

    public virtual string TagName { get; set; }

    public virtual DateTime Created { get; set; }

    public virtual string TagDescription { get; set; }
    
    //WerteBereich
    public virtual string ColorString { get; set; }

    [Timestamp]
    public virtual byte[] TimeStamp { get; set; }

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