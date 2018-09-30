using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class WrongTranslation : IHelpEntity
  {
    [Key]
    public virtual int ID_WrongTranslation { get; set; }

    public virtual string NewText { get; set; }

    public virtual string WrongText { get; set; }

    public virtual User Author { get; set; }

    public virtual DateTime Created { get; set; }

    public virtual string Description { get; set; }

    [Timestamp]
    public virtual byte[ ] TimeStamp { get; set; }

    public string GetEntityName()
    {
      throw new NotImplementedException();
    }

    public int GetID()
    {
      return ID_WrongTranslation;
    }

    public bool GetWriteHistoryEntry()
    {
      return false;
    }
  }
}