import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class VerifyService {
  constructor(private http: HttpClient) {}

  url = 'http://localhost:53810/api/Verify';

  private rp: string;

  verify(token: string): boolean {
    console.log('Token');
    console.log(token);
    const u = this.url + '?Token=' + token;
    console.log(u);
    this.http.get(this.url + '?Token=' + token).subscribe(response => {
      console.log(response);
      this.rp = response.toString();
    });
    if (this.rp === 'true') {
      return true;
    } else {
      return false;
    }
  }
}
