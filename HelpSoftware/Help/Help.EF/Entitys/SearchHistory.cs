using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class SearchHistory : IHelpEntity
  {
    [Key]
    public virtual int? ID_SearchHistory { get; set; }

    public virtual string SearchText { get; set; }

    public virtual DateTime SearchTime { get; set; }

    public virtual User SearchedUser { get; set; }

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