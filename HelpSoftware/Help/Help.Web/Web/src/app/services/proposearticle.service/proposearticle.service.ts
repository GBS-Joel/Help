import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { ArticleProposal } from "../../EF/EF";

@Injectable({
  providedIn: "root"
})
export class ProposearticleService {
  constructor(private http: HttpClient) {}

  SaveArticleProposal(Prop: ArticleProposal) {
    let instance = JSON.stringify(Prop);
    this.http.post("http://localhost:53810/api/ProposeArticle", instance);
  }
}
