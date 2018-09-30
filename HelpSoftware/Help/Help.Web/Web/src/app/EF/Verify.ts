import { User } from "./EF";

export class Verify {
  ID_Verify: number;
  User: User;
  Created: Date;
  Token: string;
  IsVerified: boolean;
  VerifyTime: Date;

  deserialize(input): Verify {
    this.ID_Verify = input.ID_Verify;
    this.User = new User().deserialize(input.User);
    this.Created = input.Created;
    this.Token = input.Token;
    this.IsVerified = input.IsVerified;
    this.VerifyTime = input.VerifyTime;
    return this;
  }
}
