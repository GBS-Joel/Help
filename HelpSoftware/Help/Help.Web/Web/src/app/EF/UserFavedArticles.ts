import { User, Article } from "./EF";

export class UserFavedArticles {
  ID_UserFavedArticles: number;
  FavedUser: User;
  FavedArticle: Article;
  FavedTime: Date;

  deserialize(input): UserFavedArticles {
    this.ID_UserFavedArticles = input.ID_UserFavedArticles;
    this.FavedUser = new User().deserialize(input.FavedUser);
    this.FavedArticle = new Article().deserialize(input.Article);
    this.FavedTime = input.FavedTime;
    return this;
  }
}
