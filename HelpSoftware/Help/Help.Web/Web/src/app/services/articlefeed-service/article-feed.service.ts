import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: "root"
})
export class ArticleFeedService {
  constructor(private http: HttpClient) {}

  url = "http://localhost:53810/api/ArticleFeed";

  getArticleFeed() {
    return this.http.get(this.url);
  }
}
