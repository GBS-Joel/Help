using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Help
{
  public class MailHandler
  {
    public static MailHandler Instance { get; set; }

    private SmtpClient MailClient { get; set; }

    private MailHandler()
    {

    }

    public static void InitInstance()
    {
      Instance = new MailHandler();
      Instance.MailClient = new SmtpClient("smtp.gmail.com", 587);
      Instance.MailClient.EnableSsl = true;
      Instance.MailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
      Instance.MailClient.UseDefaultCredentials = false;
      Instance.MailClient.Credentials = new NetworkCredential(@"tijogalp@gmail.com", MailPW.MailsPW);
    }

    public void SendMail(string Message, string Header, string recipient, EMailType type = EMailType.Push)
    {
      MailMessage message = new MailMessage(new MailAddress("joel.marty@gmail.com", "Help"), new MailAddress(recipient));
      message.Body = Message;
      message.Subject = Header;
      message.IsBodyHtml = true;
      Instance.MailClient.Send(message);
      CreateMailActivity(message, type);
    }

    public void SendActivationEMail(User u)
    {
      string FullName = u.Vorname + " " + u.Nachname;
      string mailmessage = string.Format(EMailTemplates.AccountActivatedMessageTemplate, FullName);
      Instance.SendMail(mailmessage, "Account Activation", u.EMail, EMailType.AccountActivated);
    }

    public void SendPushEMail(string Message, string Subject, string recipient, EMailType type = EMailType.Push)
    {
      SendMail(Message, Subject, recipient, type);
    }

    private void CreateMailActivity(MailMessage message, EMailType type)
    {
      MailActivity act = new MailActivity()
      {
        Recipient = message.To.First().Address,
        Sender = message.From.Address,
        SendTime = DateTime.Now,
        Subject = message.Subject,
        UserSender = AppContext.LoggedInUser,
        MailType = type.ToString()
      };
      HelpContext.Instance.MailActivities.Add(act);
      HelpContext.Instance.SaveChanges();
    }
  }
}