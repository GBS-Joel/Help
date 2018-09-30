import { User, Topic, Tag } from "./EF";

export class ArticleNomination {
  ID_ArticleNomination: Number;
  NominatedUser: User;
  RequestedUser: User;
  ArticleTitle: string;
  ArticleDescription: string;
  Comment: string;
  Topics: Topic[];
  Tags: Tag[];
  NominationedDate: Date;
  IsSeen: boolean;
  SeenDate: Date;

  deserialize(input) {
    this.ID_ArticleNomination = input.ID_ArticleNomination;
    this.NominatedUser = new User().deserialize(input.NominatedUser);
    this.RequestedUser = new User().deserialize(input.RequestedUser);
    this.ArticleTitle = input.ArticleTitle;
    this.ArticleDescription = input.ArticleDescription;
    this.Comment = input.Comment;
    this.NominationedDate = input.NominationedDate;
    this.IsSeen = input.IsSeen;
    this.SeenDate = input.Date;
    return this;
  }
}
