import { Injectable } from "@angular/core";
import { Subject, Observable } from "rxjs";
// import { Subject } from "rxjs/Subject";
// import { BehaviorSubject } from "rxjs/BehaviorSubject";
// import { Observable } from "rxjs/Observable";

@Injectable({
  providedIn: "root"
})
export class ResponsiveService {
  private isMobile = new Subject();
  public screenWidht: string;

  constructor() {
    this.checkWidth();
  }

  onMobileChange(status: boolean) {
    this.isMobile.next(status);
  }

  getMobileStatus(): Observable<any> {
    return this.isMobile.asObservable();
  }

  public checkWidth() {
    var width = window.innerWidth;
    if (width <= 768) {
      this.screenWidht = "sm";
      this.onMobileChange(true);
    } else if (width > 768 && width <= 992) {
      this.screenWidht = "md";
      this.onMobileChange(false);
    } else {
      this.screenWidht = "lg";
      this.onMobileChange(false);
    }
  }
}
