import { Injectable } from "@angular/core";
import { AuthService } from "../auth.service/auth.service";
import { UrlService } from "../url.service/url.service";
import { HttpClient } from "@angular/common/http";
import { SearchHistory } from "../../EF/EF";

@Injectable({
  providedIn: "root"
})
export class SearchhistoryService {
  constructor(
    private authService: AuthService,
    private urlService: UrlService,
    private http: HttpClient
  ) {}

  writeSearchHistory(key: string): void {
    var dt = new Date();
    dt.getFullYear() + "/" + (dt.getMonth() + 1) + "/" + dt.getDate();
    let h = new SearchHistory();
    h.SearchText = key;
    h.SearchTime = dt;
    h.ID_SearchHistory = null;
    h.SearchedUser = null;
    let json = JSON.stringify(h);
    let u = this.urlService.GetBaseURL() + "SearchHistory?Val=" + json;
    console.log(u);
    this.http.post(u, null);
  }
}
