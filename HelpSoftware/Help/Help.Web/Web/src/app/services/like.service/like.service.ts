import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { AuthService } from "../auth.service/auth.service";
import { UrlService } from "../url.service/url.service";

@Injectable({
  providedIn: "root"
})
export class LikeService {
  constructor(
    private http: HttpClient,
    private authService: AuthService,
    private urlService: UrlService
  ) {}

  url = "http://localhost:53810/api/Like";

  GetCanLike(ID_User: Number): boolean {
    if (ID_User) {
      this.http
        .get(this.urlService.GetBaseURL() + "Like/" + ID_User)
        .subscribe(data => {
          console.log(data);
        });
    }
    return true;
  }

  LikeArticle(ID_Article: Number): void {
    if (this.authService.getIsLoggedIn()) {
      this.http.post(this.url + ID_Article, null);
    }
  }

  UnLikeArticle(ID_Article: Number): void {}
}
