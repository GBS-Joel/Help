import { User } from "./EF";

export class MailActivity {
  ID_MailActivity: number;
  SendTime: Date;
  Sender: string;
  UserSender: User;
  Subject: string;
  Recipient: string;
  MailType: string;

  deserialize(input): MailActivity {
    this.ID_MailActivity = input.ID_MailActivity;
    this.SendTime = input.SendTime;
    this.Sender = input.Sender;
    this.UserSender = new User().deserialize(input.UserSender);
    this.Subject = input.Subject;
    this.Recipient = input.Recipient;
    this.MailType = input.MailType;
    return this;
  }
}
