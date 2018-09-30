import { User, Article } from "./EF";

export class ArticleComment {
  ID_ArticleComment: Number;
  Comment: string;
  CommentTitle: string;
  UserComment: User;
  CommentArticle: Article;
  CommentTime: Date;

  deserialize(input) {
    this.ID_ArticleComment = input.ID_ArticleComment;
    this.Comment = input.Comment;
    this.CommentTitle = input.CommentTitle;
    this.UserComment = new User().deserialize(input.UserComment);
    this.CommentArticle = input.CommentArticle;
    this.CommentTime = input.CommentTime;
    return this;
  }
}
