import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginMessageService {
  private isLoggedIn = new Subject<boolean>();
  constructor() {}

  public getMessage(): Observable<boolean> {
    return this.isLoggedIn.asObservable();
  }

  public updateMessage(isLoggedIn: boolean): void {
    this.isLoggedIn.next(isLoggedIn);
  }
}