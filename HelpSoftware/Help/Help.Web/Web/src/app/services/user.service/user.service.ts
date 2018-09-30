import { Injectable } from "@angular/core";
import { User } from "../../EF/User";
import { USERS } from "../../EF/mock-data";
import { Observable, of } from "rxjs";
import { MessageService } from "../message.service/message.service";

import { HttpClient, HttpHeaders } from "@angular/common/http";

@Injectable({
  providedIn: "root"
})
export class UserService {
  constructor(
    private messageService: MessageService,
    private http: HttpClient
  ) {}

  private url = "http://localhost:53810/api/User";

  getUser(): Observable<User[]> {
    this.messageService.add("HeroService: fetched heroes");
    return of(USERS);
  }

  private log(message: string) {
    this.messageService.add("UserService" + message);
  }

  getUserFromUsername(username: string) {
    return this.http.get(this.url + "?Username=" + username);
  }
}
