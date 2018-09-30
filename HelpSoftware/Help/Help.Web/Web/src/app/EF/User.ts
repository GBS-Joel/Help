export class User {
  ID_User: Number;
  Username: string;
  Password: string;
  EMail: string;
  Vorname: string;
  Nachname: string;
  Nick: string;
  Birth: Date;
  IsVerified: boolean;
  IsActive: boolean;
  ImagePath: string;
  IsAdminUser: boolean;

  deserialize(input) {
    this.ID_User = input.ID_User;
    this.Username = input.Username;
    this.Password = input.Password;
    this.EMail = input.EMail;
    this.Vorname = input.Vorname;
    this.Nachname = input.Nachname;
    this.Nick = input.Nick;
    this.Birth = input.Birth;
    this.IsVerified = input.IsVerified;
    this.IsActive = input.IsActive;
    this.ImagePath = input.ImagePath;
    this.IsAdminUser = input.IsAdminUser;
    return this;
  }
}
