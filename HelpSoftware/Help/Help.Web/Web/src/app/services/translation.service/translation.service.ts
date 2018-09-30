import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { UrlService } from "../url.service/url.service";

@Injectable({
  providedIn: "root"
})
export class TranslationService {
  constructor(private http: HttpClient, private urlService: UrlService) {}

  LoadData(): void {
    console.log(this.http);

    this.http.get("localhost:53810/api/Translation").subscribe(data => {
      console.log(data);
    });
    //let url = this.urlService.GetBaseURL().toString() + "Translation";
    console.log("localhost:53810/api/Translation");
  }
}
