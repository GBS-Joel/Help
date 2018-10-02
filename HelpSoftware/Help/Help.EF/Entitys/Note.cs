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
    public virtual byte[ ] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "Note";
    }

    public int GetID()
    {
      return ID_Note;
    }

    public bool GetWriteHistoryEntry()
    {
      return false;
    }
  }
}