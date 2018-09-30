import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HelpService } from '../services/services';

@Component({
  selector: 'app-verify',
  templateUrl: './verify.component.html',
  styleUrls: ['./verify.component.css']
})
export class VerifyComponent implements OnInit {
  constructor(private router: Router, private helpService: HelpService) {}

  token: string;

  success: boolean;

  ngOnInit() {
    const url = this.router.url;
    console.log(this.router.url);
    this.token = url.replace('/verify?TOKEN=', '');
    console.log(this.token);
    const a = this.helpService.verifyService.verify(this.token);
    console.log('test');
    console.log('test' + a);
    if (a) {
      this.success = true;
    } else {
      this.success = false;
    }
  }
}
