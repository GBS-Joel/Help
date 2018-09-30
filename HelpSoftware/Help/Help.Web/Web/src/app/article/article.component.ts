import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { Article } from "../EF/EF";
import { HelpService } from "../services/services";

@Component({
  selector: "app-article",
  templateUrl: "./article.component.html",
  styleUrls: ["./article.component.css"]
})
export class ArticleComponent implements OnInit {
  constructor(private router: Router, private helpService: HelpService) {}

  private Article: Article;

  ngOnInit() {
    console.log("STARTUP");
    this.helpService.dataService.CurrentArticle.subscribe(
      art => (this.Article = art)
    );
    if (!this.helpService.dataService.HasArticle) {
      this.router.navigateByUrl("start");
    }
    console.log(this.Article);
  }

  ViewUser(): void {
    console.log(this.Article.Author);
    this.helpService.dataService.ChangeUser(this.Article.Author);
    this.helpService.dataService.HasUser = true;
    this.router.navigateByUrl("/profileother");
  }
}