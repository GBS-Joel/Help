using System;
using System.ComponentModel.DataAnnotations;

namespace Help.EF
{
  public class MailActivity : IHelpEntity
  {
    [Key]
    public virtual int ID_MailActivity { get; set; }

    public virtual DateTime SendTime { get; set; }

    public virtual string Sender { get; set; }

    public virtual User UserSender { get; set; }

    public virtual string Subject { get; set; }

    public virtual string Recipient { get; set; }

    //Change to WerteBereich Item
    public virtual string MailType { get; set; }

    [Timestamp]
    public virtual byte[] TimeStamp { get; set; }

    public string GetEntityName()
    {
      throw new NotImplementedException();
    }

    public int GetID()
    {
      throw new NotImplementedException();
    }

    public bool GetWriteHistoryEntry()
    {
      return false;
    }
  }
}