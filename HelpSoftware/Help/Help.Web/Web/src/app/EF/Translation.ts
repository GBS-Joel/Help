export class Translation {
  ID_Translation: number;
  GermanText: string;
  EnglischText: string;
  CreatedDate: Date;

  deserialize(input) {
    this.ID_Translation = input.ID_Translation;
    this.GermanText = input.GermanText;
    this.EnglischText = input.EnglischText;
    this.CreatedDate = input.CreatedDate;
    return this;
  }
}
