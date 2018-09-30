import { User, Article } from "./EF";

export class ReviewedArticle {
  ID_ReviewedArticle: number;
  ReviewedUser: User;
  ArticleReviewed: Article;
  ReviewTime: Date;
  Comment: string;

  deserialize(input): ReviewedArticle {
    this.ID_ReviewedArticle = input.ID_ReviewedArticle;
    this.ReviewedUser = new User().deserialize(input.ReviewedUser);
    this.ArticleReviewed = new Article().deserialize(input.ArticleReviewed);
    this.ReviewTime = input.ReviewTime;
    this.Comment = input.Comment;
    return this;
  }
}