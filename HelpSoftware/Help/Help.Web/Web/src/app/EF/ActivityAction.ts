export class ActivityAction {
  ID_ActivityAction: Number;
  ActionName: string;

  deserialize(input) {
    this.ID_ActivityAction = input.ID_ActivityAction;
    this.ActionName = input.ActionName;
    return this;
  }
}
