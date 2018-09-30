import { Article, User } from "./EF";

export class ViewHistory {
  ID_ViewHistory: number;
  ViewedArticle: Article;
  ViewedUser: User;
  AccessTime: Date;

  deserialize(input) {
    this.ID_ViewHistory = input.ID_ViewHistory;
    this.ViewedArticle = new Article().deserialize(input.ViewedArticle);
    this.ViewedUser = new User().deserialize(input.ViewedUser);
    this.AccessTime = input.AccessTime;
    return this;
  }
}