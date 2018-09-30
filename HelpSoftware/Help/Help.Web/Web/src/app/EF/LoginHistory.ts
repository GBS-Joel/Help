import { User } from "./EF";

export class LoginHistory {
  ID_LoginHistory: Number;
  LoggedInUser: User;
  LoggedInTime: Date;
  LoginType: Number;

  deserialize(input) {
    this.ID_LoginHistory = input.ID_LoginHistory;
    this.LoggedInUser = new User().deserialize(input.LoggedInUser);
    this.LoggedInTime = input.LoggedInTime;
    this.LoginType = input.LoginType;
  }
}
