import { Component, OnInit } from "@angular/core";
import { User } from "../EF/User";
import { USERS } from "../EF/mock-data";
import { Article } from "../EF/Article";
import { HelpService } from "../services/services";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.css"]
})
export class HomeComponent implements OnInit {
  user: User[];

  users = USERS;

  Articles = [];
  selectedArticle: Article;

  test: User;

  constructor(private helpService: HelpService) {}

  ngOnInit(): void {
    this.getFeed();
    this.test = new User();
  }

  getFeed(): void {
    this.helpService.articlefeedService.getArticleFeed().subscribe(data => {
      let tempdata = JSON.parse(data.toString());
      this.Articles = [];
      tempdata.forEach(element => {
        let a = new Article().deserialize(element);
        this.Articles.push(a);
      });
      console.log(this.Articles);
    });
  }

  onSelect(us: User): void {
    this.test = us;
  }

  onSelectArt(art: Article): void {
    this.selectedArticle = art;
  }
}
