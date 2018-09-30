using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
  public class MailActivity
  {
    [Key]
    public int ID_MailActivity { get; set; }

    public DateTime SendTime { get; set; }

    public string Sender { get; set; }

    public User UserSender { get; set; }

    public string Subject { get; set; }

    public string Recipient { get; set; }

    public string MailType { get; set; }
  }
}