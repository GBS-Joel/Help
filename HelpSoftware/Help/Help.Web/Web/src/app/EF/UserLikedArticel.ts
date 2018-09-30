import { User, Article } from "./EF";

export class UserLikedArticel {
  ID_UserLikedArticel: number;
  LikedUser: User;
  LikedArticel: Article;
  LikedTime: Date;

  deserialize(input) {
    this.ID_UserLikedArticel = input.ID_UserLikedArticel;
    this.LikedUser = new User().deserialize(input.LikedUser);
    this.LikedArticel = new Article().deserialize(input.LikedArticel);
    this.LikedTime = input.Date;
    return this;
  }
}
