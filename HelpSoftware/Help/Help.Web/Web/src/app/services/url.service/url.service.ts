import { Injectable } from "@angular/core";

@Injectable({
  providedIn: "root"
})
export class UrlService {
  constructor() {}

  private BaseURL: string = "localhost:53810/api/";

  public GetBaseURL(): string {
    return this.BaseURL;
  }

  public SetBaseURL(url: string): void {
    this.BaseURL = url;
  }  
}
