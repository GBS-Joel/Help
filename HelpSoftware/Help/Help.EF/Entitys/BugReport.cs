using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class BugReport : IHelpEntity
  {
    [Key]
    public virtual int ID_BugReport { get; set; }

    public virtual User ReportUser { get; set; }

    public virtual DateTime ReportTime { get; set; }

    public virtual string Report { get; set; }

    public virtual string ReportTitle { get; set; }

    public virtual string Error { get; set; }

    public virtual bool Notified { get; set; }

    public virtual DateTime? NotfiyTime { get; set; }

    [Timestamp]
    public virtual byte[] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "BugReport";
    }

    public int GetID()
    {
      return ID_BugReport;
    }

    public bool GetWriteHistoryEntry()
    {
      return true;
    }
  }
}