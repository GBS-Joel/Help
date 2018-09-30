import { Injectable } from "@angular/core";
import {
  ActivityService,
  ArticleService,
  ArticleFeedService,
  AuthService,
  BugreportService,
  DataService,
  LikeService,
  LoginService,
  MessageService,
  ProfilecommentService,
  ProposearticleService,
  PushuserService,
  ResponsiveService,
  UrlService,
  TranslationService,
  SearchhistoryService,
  UserService,
  VerifyService
} from "../services";

@Injectable({
  providedIn: "root"
})
export class HelpService {
  constructor(
    public activityService: ActivityService,
    public articleService: ArticleService,
    public articlefeedService: ArticleFeedService,
    public authService: AuthService,
    public bugreportService: BugreportService,
    public dataService: DataService,
    public likeService: LikeService,
    public loginService: LoginService,
    //public messageService: MessageService,
    public profilecommentService: ProfilecommentService,
    public proposearticleService: ProposearticleService,
    public pushuserService: PushuserService,
    public responseiveService: ResponsiveService,
    public searchhistoryservice: SearchhistoryService,
    public translationService: TranslationService,
    public urlService: UrlService,
    public userService: UserService,
    public verifyService: VerifyService
  ) {}
}
