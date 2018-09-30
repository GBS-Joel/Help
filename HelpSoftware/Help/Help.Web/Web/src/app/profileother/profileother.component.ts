import { Component, OnInit } from "@angular/core";
import { User } from "../EF/EF";
import { Router } from "@angular/router";
import { HelpService } from "../services/services";

@Component({
  selector: "app-profileother",
  templateUrl: "./profileother.component.html",
  styleUrls: ["./profileother.component.css"]
})
export class ProfileotherComponent implements OnInit {
  constructor(private helpService: HelpService, private router: Router) {}

  User: User;

  Activities;

  loaded: boolean = false;

  ngOnInit() {
    this.helpService.dataService.CurrentUser.subscribe(user => {
      this.User = user;
    });
    if (!this.helpService.dataService.HasUser) {
      this.router.navigateByUrl("/start");
    }
    let a = this.helpService.activityService.GetRecentActivity(
      this.User.ID_User
    );
    this.Activities = a;
    if (this.User != undefined) {
      this.loaded = true;
    }
  }
}
