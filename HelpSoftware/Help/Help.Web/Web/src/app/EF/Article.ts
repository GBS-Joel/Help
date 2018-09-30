import { Tag, User } from "./EF";

export class Article {
  ID_Article: Number;
  ArticleText: string;
  ArticlePreview: string;
  ArticleTitle: string;
  Tags: Tag[];
  Author: User;
  Created: Date;
  LastModifiedBy: User;
  LastModifiedDate: Date;
  Views: Number;
  Stars: Number;
  Favorits: Number;
  Public: boolean;
  IsReviewed: boolean;

  constructor() {}

  deserialize(input) {
    this.ID_Article = input.ID_Article;
    this.ArticleText = input.ArticleText;
    this.ArticlePreview = input.ArticlePreview;
    this.ArticleTitle = input.ArticleTitle;
    this.Created = input.Created;
    if (input.Author){
      this.Author = new User().deserialize(input.Author);
    }
    if (input.LastModifiedBy) {
      this.LastModifiedBy = new User().deserialize(input.LastModifiedBy);
    }
    this.LastModifiedDate = input.LastModifiedBy;
    this.Views = input.Views;
    this.Stars = input.Stars;
    this.Favorits = input.Favorits;
    this.Public = input.Public;
    this.IsReviewed = input.IsReviewed;
    return this;
  }
}
