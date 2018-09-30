import { Setting, User } from "./EF";

export class UserSetting {
  ID_UserSetting: number;
  Setting: Setting;
  User: User;
  UserValue: string;
  Created: Date;
  LastChanged: Date;

  deserialize(input) {
    this.ID_UserSetting = input.ID_UserSetting;
    this.Setting = new Setting().deserialize(input.Setting);
    this.User = new User().deserialize(input.User);
    this.UserValue = input.UserValue;
    this.Created = input.Created;
    this.LastChanged = input.Date;
  }
}