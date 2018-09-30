import { Injectable } from "@angular/core";
import { AuthService } from "../auth.service/auth.service";
import { UserService } from "../user.service/user.service";
import { User } from "../../EF/EF";
import { Router } from "@angular/router";

@Injectable({
  providedIn: "root"
})
export class LoginService {
  constructor(
    private AuthService: AuthService,
    private UserService: UserService,
    private router: Router
  ) {}

  //Will set the auth
  login(dataus) {
    console.log("Start Login");
    let udata = new User();
    this.UserService.getUserFromUsername(dataus.username).subscribe(data => {
      console.log(data);
      let datainstance = JSON.parse(data.toString());
      let u = new User().deserialize(datainstance[0]);
      console.log(u);
      if (u.Password.toString() === dataus.password) {
        this.AuthService.setNewUser(u);
        this.router.navigateByUrl("profile");
      }
    });
  }
}
