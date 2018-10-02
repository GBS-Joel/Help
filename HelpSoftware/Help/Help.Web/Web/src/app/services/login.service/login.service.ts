import { Injectable } from '@angular/core';
import { AuthService } from '../auth.service/auth.service';
import { UserService } from '../user.service/user.service';
import { User } from '../../EF/EF';
import { Router } from '@angular/router';
import {
  HttpClient,
  HttpHeaders,
  HttpRequest,
  HttpParams
} from '../../../../node_modules/@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  constructor(
    private AuthService: AuthService,
    private UserService: UserService,
    private router: Router,
    private http: HttpClient
  ) {}

  // Will set the auth
  login(dataus): void {
    console.log('Start Login');

    // const httpOptions = {
    //   headers: new HttpHeaders({
    //     //'Access-Control-Allow-Origin ': '*' //application/x-www-form-urlencoded'
    //     '*': '*'
    //   })
    // };

    this.http
      .post('http://localhost:53810/token', {
        grant_type: 'password',
        Username: 'h.fischer',
        password: 'test',
        type: 'text'
      })
      .subscribe(data => {
        console.log(data);
      });

    // let udata = new User();
    // this.UserService.getUserFromUsername(dataus.username).subscribe(data => {
    //   console.log(data);
    //   let datainstance = JSON.parse(data.toString());
    //   let u = new User().deserialize(datainstance[0]);
    //   console.log(u);
    //   if (u.Password.toString() === dataus.password) {
    //     this.AuthService.setNewUser(u);
    //     this.router.navigateByUrl('profile');
    //   }
    // });
  }
}
