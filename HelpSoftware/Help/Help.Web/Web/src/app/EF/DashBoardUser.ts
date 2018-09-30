import { DashBoard, User } from "./EF";

export class DashBoardUser {
  ID_DashBoardUser: Number;
  DashBoard: DashBoard;
  User: User;
  Created: Date;

  deserialize(input) {
    this.ID_DashBoardUser = input.ID_DashBoardUser;
    this.DashBoard = new DashBoard().deserialize(input.DashBoard);
    this.User = new User().deserialize(input.User);
    this.Created = input.Created;
    return this;
  }
}
