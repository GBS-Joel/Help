using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class DashBoard : IHelpEntity
  {
    [Key]
    public virtual int ID_DashBoard { get; set; }

    public virtual string Name { get; set; }

    public virtual string Description { get; set; }

    public virtual bool IsPublic { get; set; }

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