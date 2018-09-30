import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { HelpService } from "../services/services";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"]
})
export class LoginComponent implements OnInit {
  model: any = {};
  loading = false;
  returnUrl: string;

  constructor(private router: Router, private helpService: HelpService) {}

  ngOnInit() {}

  login(): void {
    this.loading = true;
    console.log(this.model);
    this.helpService.loginService.login(this.model);
  }
}
