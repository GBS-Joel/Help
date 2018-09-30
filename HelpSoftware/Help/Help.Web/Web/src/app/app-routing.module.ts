import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule, Routes, Route } from "@angular/router";
import { DashboardComponent } from "./dashboard/dashboard.component";

import { HomeComponent } from "./home/home.component";

import { PageNotFoundComponent } from "./page-not-found/page-not-found.component";
import { LoginComponent } from "./login/login.component";
import { RegisterComponent } from "./register/register.component";
import { ReportbugComponent } from "./reportbug/reportbug.component";
import { ProfileComponent } from "./profile/profile.component";
import { VerifyComponent } from "./verify/verify.component";
import { StartComponent } from "./start/start.component";
import { ArticleComponent } from "./article/article.component";
import { ProfileotherComponent } from "./profileother/profileother.component";
import { ArticlecommentComponent } from "./articlecomment/articlecomment.component";
import { InviteComponent } from "./invite/invite.component";

const routes: Routes = [
  { path: "home", component: HomeComponent },
  { path: "dashboard", component: DashboardComponent },
  { path: "login", component: LoginComponent },
  { path: "register", component: RegisterComponent },
  { path: "reportbug", component: ReportbugComponent },
  { path: "profile", component: ProfileComponent },
  { path: "verify", pathMatch: "prefix", component: VerifyComponent },
  { path: "start", component: StartComponent },
  {
    path: "article",
    data: { some_data: "value" },
    component: ArticleComponent
  },
  {path: "invite", component: InviteComponent},
  {path: "articlecomment", component: ArticlecommentComponent},
  { path: "profileother", component: ProfileotherComponent },
  { path: "", redirectTo: "/dashboard", pathMatch: "full" },
  { path: "**", component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
