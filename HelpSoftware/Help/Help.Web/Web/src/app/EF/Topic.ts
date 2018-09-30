import { User } from "./EF";

export class Topic {
  ID_Topic: Number;
  Name: string;
  Description: string;
  ParentTopic: Topic;
  ChildTopics: Topic[];
  CreatedDate: Date;
  Author: User;
  LastModifier: User;
  LastModified: Date;

  deserialize(input) {
    this.ID_Topic = input.ID_Topic;
    this.Name = input.Name;
    this.Description = input.Description;
    this.ParentTopic = input.ParentTopic;
    this.ChildTopics = input.ChildTopics;
    this.Author = new User().deserialize(input.Author);
    this.LastModifier = input.LastModifier;
    this.LastModified = input.LastModified;
    return this;
  }
}
