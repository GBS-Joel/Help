using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class Configuration : IHelpEntity
  {
    [Key]
    public virtual int ID_Configuration { get; set; }

    public virtual string Name { get; set; }

    public virtual string Wert { get; set; }

    public virtual DateTime Created { get; set; }

    [Timestamp]
    public virtual byte[ ] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "Configuration";
    }

    public int GetID()
    {
      return ID_Configuration;
    }

    public bool GetWriteHistoryEntry()
    {
      return false;
    }
  }
}