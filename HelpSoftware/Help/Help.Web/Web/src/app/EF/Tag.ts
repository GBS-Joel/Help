export class Tag {
  ID_Tag: number;
  TagName: string;
  Created: Date;
  TagDescription: string;
  ColorString: string;

  deserialize(input) {
    this.ID_Tag = input.ID_Tag;
    this.TagName = input.TagName;
    this.Created = input.Created;
    this.TagDescription = input.TagDescription;
    this.ColorString = input.ColorString;
    return this;
  }
}
