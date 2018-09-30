import { Component, OnInit } from "@angular/core";
import { HelpService } from "../services/services";

@Component({
  selector: "app-messages",
  templateUrl: "./messages.component.html",
  styleUrls: ["./messages.component.css"]
})
export class MessagesComponent implements OnInit {
  constructor(private helpService: HelpService) {}

  ngOnInit() {}
}
