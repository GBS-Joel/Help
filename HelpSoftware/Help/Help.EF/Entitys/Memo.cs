using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class Memo : IHelpEntity
  {
    [Timestamp]
    public virtual byte[ ] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "Memo";
    }

    public int GetID()
    {
      return 0;
    }

    public bool GetWriteHistoryEntry()
    {
      return false;
    }
  }
}