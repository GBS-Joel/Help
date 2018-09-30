import { Component, OnInit } from "@angular/core";
import { ArticleProposal } from "../EF/EF";

@Component({
  selector: "app-proposearticle",
  templateUrl: "./proposearticle.component.html",
  styleUrls: ["./proposearticle.component.css"]
})
export class ProposearticleComponent implements OnInit {
  constructor() {}

  Prop: ArticleProposal;

  ngOnInit() {}

  Propose(model) {
    this.Prop = new ArticleProposal();
    this.Prop.ArticleTitle = model.ArticleTitle;
    this.Prop.ArticleDescription = model.ArticleDescription;
    this.Prop.Comment = model.Comment;
    
  }
}
