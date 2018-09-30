import { Article, User } from "./EF";

export class ArticleViewHistory{
    ID_ArticleViewHistory: Number;
    ViewTime: Date;
    User: User;
    Article: Article;
}