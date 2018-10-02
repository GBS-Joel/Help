using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class ChatMessage : IHelpEntity
  {
    [Key]
    public virtual int ID_ChatMessage { get; set; }

    public virtual string Message { get; set; }

    public virtual User UserSender { get; set; }

    public virtual User UserReciever { get; set; }

    public virtual DateTime SendTime { get; set; }

    public virtual Chat Chat { get; set; }

    [Timestamp]
    public virtual byte[ ] TimeStamp { get; set; }

    public string GetEntityName()
    {
      return "ChatMessage";
    }

    public int GetID()
    {
      return ID_ChatMessage;
    }

    public bool GetWriteHistoryEntry()
    {
      return false;
    }
  }
}