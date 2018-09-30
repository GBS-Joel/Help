import { User } from "./EF";

export class UserToken {
  ID_UserToken: number;
  User: User;
  Created: Date;
  Token: string;

  deserialize(input) {
    this.ID_UserToken = input.ID_UserToken;
    this.User = new User().deserialize(input.User);
    this.Created = input.Created;
    this.Token = input.Token;
    return this;
  }
}
