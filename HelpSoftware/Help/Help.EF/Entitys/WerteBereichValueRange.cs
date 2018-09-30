using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class WerteBereichValueRange : IHelpEntity
  {
    public WerteBereichValueRange()
    {
      WerteBereichValueRangeItems = new List<WerteBereichValueRangeItem>();
    }

    [Key]
    public virtual int ID_WerteBreichValueRange { get; set; }

    //For Direct Access via the Name
    public virtual string Name { get; set; }

    public virtual WerteBereichValueRangeType Type { get; set; }

    public virtual ICollection<WerteBereichValueRangeItem> WerteBereichValueRangeItems { get; set; }

    [Timestamp]
    public virtual byte[ ] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "WerteBereichValueRange";
    }

    public int GetID()
    {
      return ID_WerteBreichValueRange;
    }

    public bool GetWriteHistoryEntry()
    {
      return false;
    }
  }
}