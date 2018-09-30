using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class Activity : IHelpEntity
  {
    [Key]
    public virtual int ID_Activity { get; set; }

    public virtual User ActivityUser { get; set; }

    public virtual Article ActivityArticle { get; set; }

    public virtual WerteBereich ActivityAction { get; set; }

    public virtual WertebereichDef WerteBereichDef { get; set; }

    public virtual string NewValue { get; set; }

    public virtual string OldValue { get; set; }

    public virtual DateTime ActivityOn { get; set; }

    public virtual string ChangedPropertyName { get; set; }

    [Timestamp]
    public virtual byte[ ] TimeStamp { get; set; }

    public int GetID()
    {
      return ID_Activity;
    }

    public string GetEntityName()
    {
      return "Activity";
    }

    public bool GetWriteHistoryEntry()
    {
      return true;
    }
  }
}