import { Component, OnInit } from '@angular/core';
import { ResponsiveService } from './services/responsive.service/responsive.service';
import { AuthService } from './services/auth.service/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  isLoggedIn = false;

  title = 'Help.Web';

  constructor(
    private responsiveService: ResponsiveService,
    private authService: AuthService
  ) {}
  ngOnInit(): void {
    this.responsiveService.getMobileStatus().subscribe(isMobile => {
      if (isMobile) {
        console.log('Mobile device detected');
      } else {
        console.log('Desktop detected');
      }
    });
    this.onResize();
    this.authService.IsLoggedIn$.subscribe((data: boolean) => {
      this.isLoggedIn = data;
    });
  }

  onResize() {
    this.responsiveService.checkWidth();
    this.isLoggedIn = this.authService.getIsLoggedIn();
  }

  Update() {
    console.log('Focus');
  }
}
