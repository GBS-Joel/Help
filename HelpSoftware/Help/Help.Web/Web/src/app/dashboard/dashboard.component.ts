import { Component, OnInit } from "@angular/core";
import { User } from "../EF/User";
import { Location } from "@angular/common";
import { HelpService } from "../services/services";

@Component({
  selector: "app-dashboard",
  templateUrl: "./dashboard.component.html",
  styleUrls: ["./dashboard.component.css"]
})
export class DashboardComponent implements OnInit {
  users: User[] = [];
  constructor(private helpService: HelpService, private location: Location) {}

  ngOnInit() {
    this.GetUsers();
  }

  GetUsers() {
    this.helpService.userService
      .getUser()
      .subscribe(users => (this.users = users.slice(1, 5)));
  }

  goBack(): void {
    this.location.back();
  }
}