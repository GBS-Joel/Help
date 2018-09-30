using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class APIRequest : IHelpEntity
  {
    [Key]
    public virtual int ID_APIRequest { get; set; }

    public virtual string Certificate { get; set; }

    public virtual string Host { get; set; }

    public virtual string Request { get; set; }

    public virtual string Method { get; set; }

    public virtual string Response { get; set; }

    public virtual DateTime Time { get; set; }

    public virtual User LoggedInUser { get; set; }

    [Timestamp]
    public virtual byte[ ] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "APIRequest";
    }

    public int GetID()
    {
      return ID_APIRequest;
    }

    public bool GetWriteHistoryEntry()
    {
      return false;
    }
  }
}