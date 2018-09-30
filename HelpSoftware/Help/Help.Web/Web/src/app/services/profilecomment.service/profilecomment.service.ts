import { Injectable } from "@angular/core";
import { User } from "../../EF/EF";
import { HttpClient } from "@angular/common/http";
import { UrlService } from "../url.service/url.service";

@Injectable({
  providedIn: "root"
})
export class ProfilecommentService {
  constructor(private http: HttpClient, private urlService: UrlService) {}

  getCommentsFromProfile(User: User) {
    this.http.get(this.urlService.GetBaseURL() + "/");
  }
}
