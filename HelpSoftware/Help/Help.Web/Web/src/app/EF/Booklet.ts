import { User } from "./EF";

export class Booklet {
  ID_Booklet: Number;
  Name: String;
  Description: string;
  User: User;
  Created: Date;
  LastModified: Date;
  Public: boolean;

  deserialize(input): Booklet {
    this.ID_Booklet = input.ID_Booklet;
    this.Name = input.Name;
    this.Description = input.Description;
    this.User = new User().deserialize(input.User);
    this.Created = input.Created;
    this.LastModified = input.LastModified;
    this.Public = input.Public;
    return this;
  }
}
