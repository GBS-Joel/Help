import { User, Article, ActivityAction } from "./EF";

export class Activity {
  ID_Activity: Number;
  ActivityUser: User;
  ActivityArticle: Article;
  ActivityAction: ActivityAction;
  NewValue: string;
  OldValue: string;
  ActivityOn: Date;
  ChangedPropertyName: string;

  deserialize(input) {
    this.ID_Activity = input.ID_Activity;
    this.ActivityUser = input.ActivityUser;
    this.ActivityArticle = input.ActivityArticle;
    this.ActivityAction = input.ActivityAction;
    this.NewValue = input.NewValue;
    this.OldValue = input.OldValue;
    this.ActivityOn = input.ActivityOn;
    this.ChangedPropertyName = input.ChangedPropertyName;
    return this;
  }
}
