import { Component, OnInit } from "@angular/core";
import { HelpService } from "../services/services";

@Component({
  selector: "app-articlecomment",
  templateUrl: "./articlecomment.component.html",
  styleUrls: ["./articlecomment.component.css"]
})
export class ArticlecommentComponent implements OnInit {
  constructor(private helpService: HelpService) {}

  ngOnInit() {
    console.log("TS");
    if (this.helpService.dataService.HasArticle)
      this.helpService.dataService.CurrentArticle.subscribe(data => {
        console.log(data);
      });
  }
}
