import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

@Component({
  selector: "app-register",
  templateUrl: "./register.component.html",
  styleUrls: ["./register.component.css"]
})
export class RegisterComponent implements OnInit {
  model: any = {};
  loading = false;

  constructor(private router: Router) {}

  ngOnInit() {}

  register() {
    this.loading = true;
    console.log(this.model);
  }
}
