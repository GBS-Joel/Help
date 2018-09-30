import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs/internal/BehaviorSubject";
import { Article, User } from "../../EF/EF";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root"
})
export class DataService {
  constructor(private http: HttpClient) {}

  private article = new BehaviorSubject(new Article());
  CurrentArticle = this.article.asObservable();
  private url = "http://localhost:53810/api/Article/";
  private Article: Article;

  ChangeArticleNumber(ID_Article: Number) {
    this.http.get(this.url + ID_Article).subscribe(data => {
      let article: Article;
      let datainstance = JSON.parse(data.toString());
      article = new Article().deserialize(datainstance);
      this.Article = article;
      this.article.next(article);
    });
  }

  art: any;

  public HasArticle: Boolean = false;

  public HasUser: Boolean = false;

  private user = new BehaviorSubject(new User());
  CurrentUser = this.user.asObservable();

  ChangeUser(U: User) {
    this.user.next(U);
  }
}
