import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Article } from "../../EF/EF";

@Injectable({
  providedIn: "root"
})
export class ArticleService {
  constructor(private http: HttpClient) {}

  url = "http://localhost:53810/api/ArticleSearch";

  private Articles = [];

  searchArticle(suche: string) {
    this.Articles = [];
    this.http.get(this.url + "?Suche=" + suche).subscribe(data => {
      console.log(data);
      let tempdata = JSON.parse(data.toString());
      tempdata.forEach(element => {
        let a = new Article().deserialize(element);
        this.Articles.push(a);
      });
      console.log(this.Articles);
    });
    return this.Articles;
  }
}
