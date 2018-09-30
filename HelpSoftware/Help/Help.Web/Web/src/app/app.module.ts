import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { AppComponent } from "./app.component";
import { FormsModule } from "@angular/forms";
import { HomeComponent } from "./home/home.component";
import { MessagesComponent } from "./messages/messages.component";
import { AppRoutingModule } from ".//app-routing.module";
import { DashboardComponent } from "./dashboard/dashboard.component";
import { LoginComponent } from "./login/login.component";
import { PageNotFoundComponent } from "./page-not-found/page-not-found.component";
import { RegisterComponent } from "./register/register.component";
import { ReportbugComponent } from "./reportbug/reportbug.component";
import { HttpClientModule } from "@angular/common/http";
import { ProfileComponent } from "./profile/profile.component";

//Material
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import {
  MatButtonModule,
  MatMenuModule,
  MatIconModule,
  MatCardModule,
  MatSidenavModule,
  MatFormFieldModule,
  MatInputModule,
  MatTooltipModule,
  MatToolbarModule,
  MatStepperModule,
  MatSelectModule,
  MatChipsModule,
  MatDividerModule,
  MatProgressSpinnerModule,
  MatSnackBarModule
} from "@angular/material";

import { VerifyComponent } from "./verify/verify.component";
import { StartComponent } from "./start/start.component";
import { ArticleComponent } from "./article/article.component";
import { ProfileotherComponent } from "./profileother/profileother.component";
import { CalendarModule } from "angular-calendar";
import { TagInputModule } from "ngx-chips";
import { SelectModule } from "ng2-select";
import { NgDatepickerModule } from "ng2-datepicker";
import { PdfViewerModule } from "ng2-pdf-viewer";
import { MomentModule } from "ngx-moment";
import { AgmCoreModule } from "@agm/core";
import { ProposearticleComponent } from './proposearticle/proposearticle.component';
import { PushuserComponent } from './pushuser/pushuser.component';
import { ArticlecommentComponent } from './articlecomment/articlecomment.component';
import { InviteComponent } from './invite/invite.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MessagesComponent,
    DashboardComponent,
    LoginComponent,
    PageNotFoundComponent,
    RegisterComponent,
    ReportbugComponent,
    ProfileComponent,
    VerifyComponent,
    StartComponent,
    ArticleComponent,
    ProfileotherComponent,
    ProposearticleComponent,
    PushuserComponent,
    ArticlecommentComponent,
    InviteComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatMenuModule,
    MatIconModule,
    MatCardModule,
    MatSidenavModule,
    MatFormFieldModule,
    MatInputModule,
    MatTooltipModule,
    MatToolbarModule,
    MatStepperModule,
    MatSelectModule,
    MatChipsModule,
    MatDividerModule,
    MatProgressSpinnerModule,
    CalendarModule.forRoot(),
    TagInputModule,
    SelectModule,
    NgDatepickerModule,
    PdfViewerModule,
    MomentModule,
    AgmCoreModule,
    MatSnackBarModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
