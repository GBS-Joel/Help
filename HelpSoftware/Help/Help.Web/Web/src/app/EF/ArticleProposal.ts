import { Topic, Tag, User } from "./EF";

export class ArticleProposal {
  ID_ArticleProposal: Number;
  ArticleTitle: string;
  ArticleDescription: string;
  Comment: string;
  Topics: Topic[];
  Tags: Tag[];
  CreatedDate: Date;
  AssignedUser: User;
  RequesterName: string;
  RequesterEMail: string;

  deserialize(input) {
    this.ID_ArticleProposal = input.ID_ArticleProposal;
    this.ArticleTitle = input.ArticleTitle;
    this.ArticleDescription = input.ArticleDescription;
    this.Comment = input.Comment;
    this.CreatedDate = input.CreatedDate;
    this.AssignedUser = input.AssignedUser;
    this.RequesterName = input.RequesterName;
    this.RequesterEMail = input.RequesterEMail;
    return this;
  }
}
