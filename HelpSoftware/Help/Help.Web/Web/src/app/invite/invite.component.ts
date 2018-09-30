import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HelpService } from '../services/services';

@Component({
  selector: 'app-invite',
  templateUrl: './invite.component.html',
  styleUrls: ['./invite.component.css']
})
export class InviteComponent implements OnInit {
  constructor(private router: Router, private helpService: HelpService) {}

  token: string;

  success: boolean;

  ngOnInit() {
    const url = this.router.url;
    console.log(url);
    this.token = url.replace('/invite?TOKEN=', '');
    console.log(this.token);

  }
}
