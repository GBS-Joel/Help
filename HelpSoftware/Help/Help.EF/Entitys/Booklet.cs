using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class Booklet : IHelpEntity
  {
    [Key]
    public virtual int ID_Booklet { get; set; }

    public virtual string Name { get; set; }

    public virtual string Description { get; set; }

    public virtual User User { get; set; }

    public virtual DateTime Created { get; set; }

    public virtual DateTime? LastModified { get; set; }

    public virtual bool Public { get; set; }

    [Timestamp]
    public virtual byte[] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "Booklet";
    }

    public int GetID()
    {
      return ID_Booklet;
    }

    public bool GetWriteHistoryEntry()
    {
      return true;
    }
  }
}