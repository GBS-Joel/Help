import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Activity } from "../../EF/EF";

@Injectable({
  providedIn: "root"
})
export class ActivityService {
  constructor(private http: HttpClient) {}

  private url = "http://localhost:53810/api/Activity/";

  private Activites;

  GetRecentActivity(ID_User: Number) {
    this.http.get(this.url + ID_User).subscribe(data => {
      let datainstance = JSON.parse(data.toString());
      let i = [];
      datainstance.forEach(element => {
        i.push(new Activity().deserialize(element));
      });
      console.log(i);
      this.Activites = i;
    });
    return this.Activites;
  }
}
