using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class Note : IHelpEntity
  {
    [Key]
    public virtual int ID_Note { get; set; }

    public virtual string NoteName { get; set; }

    public virtual DateTime Created { get; set; }

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
      return false;
    }
  }
}