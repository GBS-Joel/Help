import { User } from "./EF";

export class SearchHistory {
  ID_SearchHistory: number;
  SearchText: string;
  SearchTime: Date;
  SearchedUser: User;

  deserialize(input): SearchHistory {
    this.ID_SearchHistory = input.ID_SearchHistory;
    this.SearchText = input.SearchText;
    this.SearchTime = input.SearchTime;
    this.SearchedUser = new User().deserialize(input.SearchedUser);
    return this;
  }
}
