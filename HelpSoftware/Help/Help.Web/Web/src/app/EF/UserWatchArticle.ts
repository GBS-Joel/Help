import { User, Article } from "./EF";

export class UserWatchArticle {
  ID_UserWatchArticle: number;
  WatchedUser: User;
  WatchedArticle: Article;
  WatchedTime: Date;

  deserialize(input): UserWatchArticle {
    this.ID_UserWatchArticle = input.ID_UserWatchArticle;
    this.WatchedUser = new User().deserialize(input.WatchedUser);
    this.WatchedArticle = new Article().deserialize(input.WatchedArticle);
    this.WatchedTime = input.WatchedTime;
    return this;
  }
}
