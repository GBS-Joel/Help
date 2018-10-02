import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpResponse,
  HttpErrorResponse
} from '@angular/common/http';
import { AuthService } from './auth.service';
import { Observable } from '../../../node_modules/rxjs';
import { TagPlaceholder } from '../../../node_modules/@angular/compiler/src/i18n/i18n_ast';
import { tap } from 'rxjs/operators';
import { Router } from '../../../node_modules/@angular/router';
import { MessageService } from '../services/services';
import { getTypeNameForDebugging } from '../../../node_modules/@angular/core/src/change_detection/differs/iterable_differs';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {
  constructor(
    public auth: AuthService,
    private router: Router,
    private msg: MessageService
  ) {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    console.log('Inject Token:');
    console.log(this.auth.getToken());
    request = request.clone({
      setHeaders: {
        Authorization: `bearer ${this.auth.getToken()}`
      }
    });
    // request = request.clone({
    //   setHeaders: { 'Access-Control-Allow-Origin': '*' }
    // });
    return next.handle(request).pipe(
      tap(
        event => {
          if (event instanceof HttpResponse) {

          }
        },
        error => {
          if (error instanceof HttpErrorResponse) {
            console.log(error.status);
            this.auth.collectFailedRequest(request);
            if (error.status === 401) {
              this.msg.add('You are not logged in! Log in first');
              this.router.navigate(['login']);
            } else {
              this.msg.add('There went something wrong!');
            }
          }
        }
      )
    );
  }
}
