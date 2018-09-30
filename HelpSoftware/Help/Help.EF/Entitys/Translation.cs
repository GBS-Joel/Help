using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class Translation : IHelpEntity
  {
    [Key]
    public virtual int ID_Translation { get; set; }

    public virtual string GermanText { get; set; }

    public virtual string EnglischText { get; set; }

    public virtual string FrenchText { get; set; }

    public virtual DateTime CreatedDate { get; set; }

    [Timestamp]
    public byte[ ] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "Translation";
    }

    public int GetID()
    {
      return ID_Translation;
    }

    public bool GetWriteHistoryEntry()
    {
      return false;
    }
  }
}