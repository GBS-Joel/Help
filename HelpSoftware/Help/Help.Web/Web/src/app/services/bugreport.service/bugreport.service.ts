import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: "root"
})
export class BugreportService {
  constructor(private http: HttpClient) {}

  url: string = "http://localhost:53810/api/BugReport";

  createReport(data: any) {
    let response = "";
    console.log("Start Report");
    console.log(JSON.stringify(data));
    this.http
      .post(this.url + "?title=" + data.title + "&body=" + data.error, data)
      .subscribe(data => console.log(data), (response = data));
    if ((response = "success")) {
      return true;
    } else {
      return false;
    }
  }
}
