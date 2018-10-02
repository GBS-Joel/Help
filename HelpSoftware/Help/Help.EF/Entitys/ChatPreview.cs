using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class ChatPreview : IHelpEntity
  {
    [Key]
    public virtual int ID_ChatPreview { get; set; }

    public virtual User SenderUser { get; set; }

    public virtual User ReciverUser { get; set; }

    public virtual DateTime? LastChanged { get; set; }

    [Timestamp]
    public virtual byte[ ] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "ChatPreview";
    }

    public int GetID()
    {
      return ID_ChatPreview;
    }

    public bool GetWriteHistoryEntry()
    {
      return false;
    }
  }
}