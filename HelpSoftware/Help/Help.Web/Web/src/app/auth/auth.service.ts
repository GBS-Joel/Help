import { Injectable } from '@angular/core';
import { HttpRequest } from '../../../node_modules/@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor() {}

  cachedRequests: Array<HttpRequest<any>> = [];

  public collectFailedRequest(request): void {
    this.cachedRequests.push(request);
  }

  public retryFailedRequests(): void {}

  public getToken(): string {
    return 'dsjCRZ3hCXfIFpUXjd9TPe31R3R7QnxmHCjx7NdnMt8z_Z1pjkIEEHs_6CGKLOoPDaoIkb-nIBGJ5sQT6DqgC GR-7Ijln9HYfOsXSzT_2FnqdsUpBZT1rVLOIpKS21zhCHFZid22xRJU0MxIKC-xJefKXU3tzmJy1jkpR1pm36j4XcV30c6wK3R9WXElHKWKHKxXxWN1vBkHJh6e0SuYrF53FQ9THxqzkDzd5xSxfABHjLhFGI6Rnn6Ku8wcH5NC'.toString();
    //     return localStorage.getItem('token');
  }

  public isAuthenticated(): boolean {
    const token = this.getToken();
    if (token != null) {
      return true;
    } else {
      return false;
    }
  }
}
