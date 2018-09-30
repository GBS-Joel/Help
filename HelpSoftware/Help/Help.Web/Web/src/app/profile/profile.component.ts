import { Component, OnInit } from "@angular/core";
import { User } from "../EF/EF";
import { Router } from "@angular/router";
import { HelpService } from "../services/services";

@Component({
  selector: "app-profile",
  templateUrl: "./profile.component.html",
  styleUrls: ["./profile.component.css"]
})
export class ProfileComponent implements OnInit {
  constructor(private helpService: HelpService, private router: Router) {}
  private UserAuth: User;
  private NoUser: User;

  ngOnInit() {
    this.NoUser = new User();
    this.UserAuth = this.helpService.authService.getLoggedInUser();
    if (this.UserAuth == undefined) {
      this.router.navigateByUrl("login");
    } else {
      this.NoUser = null;
    }
  }

  createFake() {
    console.log("Login");
    this.UserAuth = new User();
    this.UserAuth.ID_User = 1;
    this.UserAuth.Username = "Test";
    this.helpService.authService.setNewUser(this.UserAuth);
    //this.helpService.messageService.add("Created Fake Account");
  }

  auth() {
    let u = new User();
    u.Username = "h.fischer";
    u.Password = "test";
    console.log(u);
    this.helpService.loginService.login(u);
    let loggedninuser = this.helpService.authService.getLoggedInUser();
    this.UserAuth = loggedninuser;
    this.NoUser = null;
  }
}
