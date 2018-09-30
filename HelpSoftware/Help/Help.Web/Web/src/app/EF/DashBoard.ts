export class DashBoard {
  ID_DashBoard: Number;
  Name: string;
  Description: string;

  deserialize(input) {
    this.ID_DashBoard = input.ID_DashBoard;
    this.Name = input.Name;
    this.Description = input.Description;
    return this;
  }
}
