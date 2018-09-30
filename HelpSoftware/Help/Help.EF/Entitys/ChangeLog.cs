using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Help.EF
{
  public class ChangeLog : IHelpEntity
  {
    [Key, Column(Order = 0)]
    public int ID_ChangeLog { get; set; }

    public int LaufNr { get; set; }

    public string EntityName { get; set; }

    public int ID_Entity { get; set; }

    public string PropertyName { get; set; }

    public string Original { get; set; }

    public string Current { get; set; }

    //TODO Replace to WerteBereich
    public int Action { get; set; }

    [Timestamp]
    public virtual byte[] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "ChangeLog";
    }

    public int GetID()
    {
      return ID_ChangeLog;
    }

    public bool GetWriteHistoryEntry()
    {
      return false;
    }
  }
}