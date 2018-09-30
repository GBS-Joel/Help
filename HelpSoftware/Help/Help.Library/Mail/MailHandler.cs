using Help.EF;
using System;
using System.Linq;
using System.Net.Mail;

namespace Help.Library
{
  public class MailHandler
  {
    private SmtpClient MailClient { get; set; }

    private MailHandler()
    {
    }

    public static void InitInstance()
    {
      //TODO: Load Login Credentials from the Database
      AppContext.Logger.Debug("Init Mail Handler Instance");
      //try
      //{
      //  Instance = new MailHandler();
      //  Instance.MailClient = new SmtpClient("smtp.gmail.com", 587);
      //  Instance.MailClient.EnableSsl = true;
      //  Instance.MailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
      //  Instance.MailClient.UseDefaultCredentials = false;
      //  Instance.MailClient.Credentials = new NetworkCredential();
      //}
      //catch (Exception)
      //{
      //  throw;
      //}
    }

    public void SendMail(string Message, string Header, string recipient, EMailType type = EMailType.Push)
    {
      if (!AppContext.IsDevelopement)
      {
        MailMessage message = new MailMessage(new MailAddress("", "Help"), new MailAddress(recipient));
        message.Body = Message;
        message.Subject = Header;
        message.IsBodyHtml = true;
        MailClient.Send(message);
        CreateMailActivity(message, type);
      }
    }

    public void SendActivationEMail(User u)
    {
      string FullName = u.Vorname + " " + u.Nachname;
      string mailmessage = string.Format(EMailTemplates.AccountActivatedMessageTemplate, FullName);
      SendMail(mailmessage, "Account Activation", u.EMail, EMailType.AccountActivated);
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