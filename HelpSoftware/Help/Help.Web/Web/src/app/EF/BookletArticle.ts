import { Booklet, Article } from "./EF";

export class BookletArticle {
  ID_BookletArticle: Number;
  Book: Booklet;
  Article: Article;
  AssingTime: Date;

  deserialize(input): BookletArticle {
    this.ID_BookletArticle = input.ID_BookletArticle;
    this.Book = new Booklet().deserialize(input.Booklet);
    this.Article = new Article().deserialize(input.Article);
    this.AssingTime = input.AssingTime;
    return this;
  }
}
