import { Injectable } from "@angular/core";
import { MatSnackBar } from "@angular/material";

@Injectable({
  providedIn: "root"
})
export class MessageService {
  messages: string[] = [];

  constructor(public snackBar: MatSnackBar) {}

  add(message: string) {
    // this.snackBar.open(message, null, { duration: 5000 });
  }

  clear() {
    //this.messages = [];
  }
}
