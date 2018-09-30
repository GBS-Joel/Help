using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class OpenConnection : IHelpEntity
  {
    [Key]
    public virtual int ID_ConnectedUser { get; set; }

    public virtual User ConUser { get; set; }

    public virtual string IP { get; set; }

    public virtual string MachineName { get; set; }

    public virtual DateTime LastAction { get; set; }

    public virtual DateTime Connected { get; set; }

    [Timestamp]
    public virtual byte[] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "OpenConnection";
    }

    public int GetID()
    {
      return ID_ConnectedUser;
    }

    public bool GetWriteHistoryEntry()
    {
      return false;
    }
  }
}