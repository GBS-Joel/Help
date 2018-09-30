import { Injectable } from '@angular/core';
import { User } from '../../EF/EF';
import { Subject } from 'rxjs/internal/Subject';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor() {}

  private LoggedInUser: User;

  private IsLoggedIn = new Subject<boolean>();
  IsLoggedIn$ = this.IsLoggedIn.asObservable();

  getLoggedInUser(): User {
    console.log('Get Active User');
    if (this.LoggedInUser) {
      return this.LoggedInUser;
    }
  }

  setNewUser(user: User): void {
    this.LoggedInUser = user;
    this.IsLoggedIn.next(true);
  }

  getIsLoggedIn(): boolean {
    if (this.LoggedInUser != null) {
      return true;
    } else {
      return false;
    }
  }
}
