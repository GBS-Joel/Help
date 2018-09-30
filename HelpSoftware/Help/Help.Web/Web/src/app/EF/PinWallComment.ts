import { User } from "./EF";

export class PinWallComment {
  ID_PinWallComment: number;
  Author: User;
  User: User;
  CommentTime: Date;
  CommentTitle: string;
  CommentText: string;
  IsPublic: boolean;
  IsDeleted: boolean;
  IsAnonymous: boolean;

  deserialize(input): PinWallComment {
    this.ID_PinWallComment = input.ID_PinWallComment;
    this.Author = new User().deserialize(input.Author);
    this.User = new User().deserialize(input.User);
    this.CommentTime = input.CommentTime;
    this.CommentTitle = input.CommentTitle;
    this.CommentText = input.CommentText;
    this.IsPublic = input.IsPublic;
    this.IsDeleted = input.IsDeleted;
    this.IsAnonymous = input.IsAnonymous;
    return this;
  }
}
