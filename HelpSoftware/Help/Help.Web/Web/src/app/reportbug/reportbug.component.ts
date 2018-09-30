import { Component, OnInit } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { UserService } from "../services/user.service/user.service";
import { BugreportService } from "../services/bugreport.service/bugreport.service";
import { HelpService } from "../services/services";

@Component({
  selector: "app-reportbug",
  templateUrl: "./reportbug.component.html",
  styleUrls: ["./reportbug.component.css"]
})
export class ReportbugComponent implements OnInit {
  constructor(private http: HttpClient, private helpService: HelpService) {}
  model: any = {};
  ngOnInit() {}

  report() {
    console.log(this.model);
    let re = this.helpService.bugreportService.createReport(this.model);
    console.log(re);
  }
}
