import { Article, Tag, User } from "./EF";

export class ArticleTag{
    ID_ArticleTag: Number;
    Article: Article;
    Tag: Tag;
    AssingTime: Date;
    User: User;

   deserialize(input){
    this.ID_ArticleTag = input.ID_ArticleTag;
    this.Article = new Article().deserialize(input.Article);
    this.Tag = new Tag().deserialize(input.Tag);
    this.AssingTime = input.AssingTime;
    this.User = new User().deserialize(input.User);
    return this;
   }
}