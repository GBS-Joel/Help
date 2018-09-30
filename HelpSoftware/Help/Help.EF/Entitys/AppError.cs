using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class AppError : IHelpEntity
  {
    [Key]
    public virtual int ID_AppError { get; set; }

    public virtual string ErrorMessage { get; set; }

    public virtual string StackTrace { get; set; }

    public virtual DateTime Created { get; set; }

    [Timestamp]
    public virtual byte[ ] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "AppError";
    }

    public int GetID()
    {
      return ID_AppError;
    }

    public bool GetWriteHistoryEntry()
    {
      return false;
    }
  }
}