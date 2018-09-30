import { User } from "./EF";

export class WrongTranslation {
  ID_WrongTranslation: number;
  NewText: string;
  WrongText: string;
  Author: User;
  Created: Date;
  Description: string;

  deserialize(input): WrongTranslation {
    this.ID_WrongTranslation = input.ID_WrongTranslation;
    this.NewText = input.NewText;
    this.WrongText = input.WrongText;
    this.Author = new User().deserialize(input.Author);
    this.Created = input.Created;
    this.Description = input.Description;
    return this;
  }
}
