import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { HelpService } from "../services/services";

@Component({
  selector: "app-start",
  templateUrl: "./start.component.html",
  styleUrls: ["./start.component.css"]
})
export class StartComponent implements OnInit {
  constructor(public helpService: HelpService, private router: Router) {}

  isSearching: boolean;

  Articles;

  searchTerm;

  SelectedArticle;

  ngOnInit() {
    this.isSearching = false;
    this.helpService.dataService.CurrentArticle.subscribe(
      article => (this.SelectedArticle = article)
    );
  }

  Search(search) {
    this.helpService.searchhistoryservice.writeSearchHistory(search);
    if (!this.isSearching) {
      this.isSearching = true;
      this.searchTerm = search;
      let data = this.helpService.articleService.searchArticle(search);
      this.Articles = data;
      this.isSearching = false;
    }
  }

  View(item): void {
    console.log(item);
    this.helpService.dataService.ChangeArticleNumber(item.ID_Article);
    this.helpService.dataService.HasArticle = true;
    this.router.navigateByUrl("/article");
  }

  Comment(item): void {
    if (this.helpService.authService.getIsLoggedIn()) {
      this.helpService.dataService.ChangeArticleNumber(item.ID_Article);
      this.helpService.dataService.HasArticle = true;
      this.router.navigateByUrl("/articlecomment");
    } else {
      console.log("your are not logged in");
      this.router.navigateByUrl("login");
    }
  }

  Like(item): void {
    console.log("You Liked the article");
  }
}
